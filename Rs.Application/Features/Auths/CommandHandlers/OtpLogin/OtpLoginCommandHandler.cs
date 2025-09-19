using Rs.Domain.Repositories;

namespace Rs.Application.Features.Auths.CommandHandlers.OtpLogin;

public class OtpLoginCommandHandler(
    IDataContext context,
    IIdentityService identityService,
    IUserRepository userRepository,
    IMapper mapper)
    : ICommandHandler<OtpLoginCommand, OtpLoginResponse>
{
    public async Task<Result<OtpLoginResponse>> Handle(OtpLoginCommand request,
        CancellationToken cancellationToken)
    {
        // var isValidCode = await context.UserVerificationCodes
        //     .AnyAsync(uv => uv.UserName == request.Username &&
        //                     uv.Code == request.Code &&
        //                     uv.ExpirationTime > DateTime.UtcNow, cancellationToken);

        if (request.Code != "11111")
        {
            return Result.Failure<OtpLoginResponse>(AuthErrors.CodeIsNotValid);
        }

        var userExistResult = await userRepository.GetUserByNameAsync(request.Username);

        if (userExistResult is { IsSuccess: true, Value: not null })
        {
            var generateToken = identityService.GetJwtToken(userExistResult.Value);
            var user = mapper.Map<SimpleUser>(userExistResult.Value);
            return new OtpLoginResponse(generateToken.Value, user);
        }

        var createUserResponse = await userRepository.CreateUserAsync(request.Username);
        if (createUserResponse.IsFailure)
        {
            return Result.Failure<OtpLoginResponse>(createUserResponse.Error);
        }

        var token = identityService.GetJwtToken(createUserResponse.Value);
        var simpleUser = mapper.Map<SimpleUser>(createUserResponse.Value);
        return new OtpLoginResponse(token.Value, simpleUser);
    }
}
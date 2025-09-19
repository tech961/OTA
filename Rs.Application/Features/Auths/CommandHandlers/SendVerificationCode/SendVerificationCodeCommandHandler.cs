namespace Rs.Application.Features.Auths.CommandHandlers.SendVerificationCode;

public class SendVerificationCodeCommandHandler(
    VerificationSettings verificationSettings,
    ITokenProviderService tokenProviderService,
    IDataContext context)
    : ICommandHandler<SendVerificationCodeCommand, bool>
{
    public async Task<Result<bool>> Handle(
        SendVerificationCodeCommand request,
        CancellationToken cancellationToken)
    {
        var checkExistTokenForThisPhoneNumber = await context.UserVerificationCodes
            .FirstOrDefaultAsync(uv => uv.UserName == request.Username &&
                                       uv.ExpirationTime > DateTime.UtcNow, cancellationToken);

        if (checkExistTokenForThisPhoneNumber is not null)
        {
            return true;
        }

        // var token = tokenProviderService.GenerateToken();
        var token = "11111";
        var createNewToken = UserVerificationCode.AddCode(
            token,
            request.Username,
            verificationSettings.ExpirationTime);

        // Raised send sms event 
        await context.UserVerificationCodes.AddAsync(createNewToken, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
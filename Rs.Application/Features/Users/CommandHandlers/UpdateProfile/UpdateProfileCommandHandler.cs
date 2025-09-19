namespace Rs.Application.Features.Users.CommandHandlers.UpdateProfile;

public class UpdateProfileCommandHandler(
    IDataContext context,
    IMapper mapper,
    IUser user)
    : ICommandHandler<UpdateProfileCommand, UpdateProfileResponse>
{
    public async Task<Result<UpdateProfileResponse>> Handle(UpdateProfileCommand request
        , CancellationToken cancellationToken)
    {
        var userModel = await context.Users
            .SingleOrDefaultAsync(us => user.Id != null && us.Id == user.Id.Value, cancellationToken);

        if (userModel == null)
        {
            return Result.Failure<UpdateProfileResponse>(UserErrors.UserNotFound);
        }
        
        userModel.UpdateUser(request.FirstName, request.LastName);
        await context.SaveChangesAsync(cancellationToken);

        var updateResponse =  mapper.Map<UpdateProfileResponse>(userModel);

        return updateResponse;
    }
}
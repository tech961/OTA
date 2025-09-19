namespace Rs.Application.Features.Users.CommandHandlers.UploadProfilePic;

public class UpdateUserResult(User user, Guid? currentProfilePicId)
{
    public User User { get; set; } = user;
    public Guid? CurrentProfilePicId { get; set; } = currentProfilePicId;
}
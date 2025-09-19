namespace Rs.Application.Features.Users.CommandHandlers.UploadProfilePic;

[AutoMap(typeof(User))]
public sealed class UploadProfilePicResponse()
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName => StringUtility.GetFullName(FirstName, LastName);

    public Guid? ProfilePicId { get; set; }

    public string Role => "User";
}
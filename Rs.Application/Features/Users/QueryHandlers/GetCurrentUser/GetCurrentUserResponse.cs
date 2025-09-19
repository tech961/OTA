using System.Reflection.Metadata.Ecma335;

namespace Rs.Application.Features.Users.QueryHandlers.GetCurrentUser;

[AutoMap(typeof(User))]
public sealed class GetCurrentUserResponse
{
    public string? UserName { get; set; }
    
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    public string? FullName => $"{FirstName} {LastName}";

    public string? ProfilePic { get; set; }

    public string Role => "User";
}
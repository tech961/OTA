namespace Rs.Application.Features.Auths.CommandHandlers.OtpLogin;

public sealed class OtpLoginResponse(string token , SimpleUser user)
{
    public string Token { get; set; } = token;

    public SimpleUser User { get; set; } = user;
}

[AutoMap(typeof(User))]
public sealed class SimpleUser
{
    public string UserName { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName => StringUtility.GetFullName(FirstName, LastName);

    public Guid? ProfilePicId { get; set; }

    public string Role => "User";

    public bool IsInitial => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
}
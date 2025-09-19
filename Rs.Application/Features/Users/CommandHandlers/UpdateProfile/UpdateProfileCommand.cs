namespace Rs.Application.Features.Users.CommandHandlers.UpdateProfile;

public sealed record UpdateProfileCommand : ICommand<UpdateProfileResponse>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}
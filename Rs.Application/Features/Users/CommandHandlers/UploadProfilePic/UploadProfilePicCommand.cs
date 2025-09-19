namespace Rs.Application.Features.Users.CommandHandlers.UploadProfilePic;

public sealed record UploadProfilePicCommand(IFormFile File) : ICommand<UploadProfilePicResponse>;

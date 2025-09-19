namespace Rs.Application.Features.Users.CommandHandlers.UploadProfilePic;

public class UploadProfilePicCommandValidator: AbstractValidator<UploadProfilePicCommand>
{
    public UploadProfilePicCommandValidator(FileUploadSettings fileSettings)
    {
        RuleFor(x => x.File)
            .NotNull().WithMessage("No file uploaded.")
            .Must(file => file != null && file.Length > 0).WithMessage("File is empty.")
            .Must(file => file != null && file.Length <= fileSettings.MaxFileSize)
            .WithMessage($"File size exceeds the limit of {fileSettings.MaxFileSize / (1024 * 1024)} MB.")
            .Must(file =>
                file != null && fileSettings.AllowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage($"Invalid file type. Allowed types are {string.Join(", ", fileSettings.AllowedExtensions)}.");
    }
}
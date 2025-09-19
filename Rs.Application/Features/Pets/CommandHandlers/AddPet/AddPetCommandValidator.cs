namespace Rs.Application.Features.Pets.CommandHandlers.AddPet;

using System.IO;

public class AddPetCommandValidator : AbstractValidator<AddPetCommand>
{
    public AddPetCommandValidator(FileUploadSettings fileSettings)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(c => c.Photo)
            .NotNull().WithMessage("Photo is required.")
            .Must(file => file.Length > 0).WithMessage("Photo is empty.")
            .Must(file => file.Length <= fileSettings.MaxFileSize)
            .WithMessage($"File size exceeds the limit of {fileSettings.MaxFileSize / (1024 * 1024)} MB.")
            .Must(file => fileSettings.AllowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage($"Invalid file type. Allowed types are {string.Join(", ", fileSettings.AllowedExtensions)}.");
    }
}

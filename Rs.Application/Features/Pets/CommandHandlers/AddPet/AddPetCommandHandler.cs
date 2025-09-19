using System.IO;
using Rs.Domain.Aggregates.Pets;

namespace Rs.Application.Features.Pets.CommandHandlers.AddPet;

public class AddPetCommandHandler(
    IDataContext context,
    IMapper mapper,
    ILogger<AddPetCommandHandler> logger,
    IFileService fileService,
    FileUploadSettings fileUploadSettings,
    IUser user)
    : ICommandHandler<AddPetCommand, AddPetResponse>
{
    public async Task<Result<AddPetResponse>> Handle(AddPetCommand request, CancellationToken cancellationToken)
    {
        var uploadResult = await fileService.UploadFileAsync(request.Photo,
            Path.Combine(fileUploadSettings.UploadFolder, "pet"));

        if (uploadResult.IsFailure)
        {
            return Result.Failure<AddPetResponse>(uploadResult.Error);
        }

        var pet = new Pet(Guid.NewGuid(),
            request.Name,
            uploadResult.Value.PhysicalPath,
            request.BirthYear,
            request.Species,
            request.Breed,
            request.Gender,
            request.LivingSituation,
            request.WeightKg,
            request.City,
            user.Id!.Value,
            null!,
            false);

        await context.Pets.AddAsync(pet, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<AddPetResponse>(pet);
        return response;
    }
}

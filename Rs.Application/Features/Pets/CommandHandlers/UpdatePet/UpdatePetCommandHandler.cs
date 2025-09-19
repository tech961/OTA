using System.IO;
using Rs.Domain.Aggregates.Pets;

namespace Rs.Application.Features.Pets.CommandHandlers.UpdatePet;

public class UpdatePetCommandHandler(
    IDataContext context,
    IMapper mapper,
    ILogger<UpdatePetCommandHandler> logger,
    IFileService fileService,
    FileUploadSettings fileUploadSettings)
    : ICommandHandler<UpdatePetCommand, UpdatePetResponse>
{
    public async Task<Result<UpdatePetResponse>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await context.Pets.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (pet == null)
        {
            return Result.Failure<UpdatePetResponse>(PetErrors.NotFound);
        }

        pet.Name = request.Name;

        if (request.Photo is not null)
        {
            var uploadResult = await fileService.UploadFileAsync(request.Photo,
                Path.Combine(fileUploadSettings.UploadFolder, "pet"));

            if (uploadResult.IsFailure)
            {
                return Result.Failure<UpdatePetResponse>(uploadResult.Error);
            }

            pet.PhotoUrl = uploadResult.Value.PhysicalPath;
        }

        pet.BirthYear = request.BirthYear;
        pet.Species = request.Species;
        pet.Breed = request.Breed;
        pet.Gender = request.Gender;
        pet.LivingSituation = request.LivingSituation;
        pet.WeightKg = request.WeightKg;
        pet.City = request.City;
        pet.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<UpdatePetResponse>(pet);
        return response;
    }
}

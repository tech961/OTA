using Rs.Domain.Shared.Enums.Pet;

namespace Rs.Application.Features.Pets.CommandHandlers.AddPet;

public sealed record AddPetCommand(
    string Name,
    IFormFile Photo,
    int? BirthYear,
    Species Species,
    string Breed,
    Gender Gender,
    LivingSituation LivingSituation,
    double? WeightKg,
    string City
) : ICommand<AddPetResponse>;

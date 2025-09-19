using Rs.Domain.Shared.Enums.Pet;

namespace Rs.Application.Features.Pets.CommandHandlers.UpdatePet;

using Microsoft.AspNetCore.Http;

public sealed record UpdatePetCommand(
    Guid Id,
    string Name,
    IFormFile? Photo,
    int? BirthYear,
    Species Species,
    string Breed,
    Gender Gender,
    LivingSituation LivingSituation,
    double? WeightKg,
    string City
) : ICommand<UpdatePetResponse>;

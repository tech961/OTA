namespace Rs.Application.Features.Pets.QueryHandlers.GetPet;

public sealed record GetPetQuery(Guid Id) : IQuery<GetPetResponse>;

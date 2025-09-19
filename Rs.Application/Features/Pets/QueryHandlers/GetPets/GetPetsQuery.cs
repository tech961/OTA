namespace Rs.Application.Features.Pets.QueryHandlers.GetPets;

public sealed record GetPetsQuery() : IQuery<List<GetPetsResponse>>;

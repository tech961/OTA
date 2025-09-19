using AutoMapper.QueryableExtensions;

namespace Rs.Application.Features.Pets.QueryHandlers.GetPets;

public class GetPetsQueryHandler(IDataContext context, IMapper mapper)
    : IQueryHandler<GetPetsQuery, List<GetPetsResponse>>
{
    public async Task<Result<List<GetPetsResponse>>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
    {
        var pets = await context.Pets.AsNoTracking()
            .ProjectTo<GetPetsResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return pets;
    }
}

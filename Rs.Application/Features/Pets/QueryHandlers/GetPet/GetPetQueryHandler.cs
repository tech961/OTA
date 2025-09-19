using Rs.Domain.Aggregates.Pets;

namespace Rs.Application.Features.Pets.QueryHandlers.GetPet;

public class GetPetQueryHandler(IDataContext context, IMapper mapper)
    : IQueryHandler<GetPetQuery, GetPetResponse>
{
    public async Task<Result<GetPetResponse>> Handle(GetPetQuery request, CancellationToken cancellationToken)
    {
        var pet = await context.Pets.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (pet == null)
        {
            return Result.Failure<GetPetResponse>(PetErrors.NotFound);
        }

        var response = mapper.Map<GetPetResponse>(pet);
        return response;
    }
}

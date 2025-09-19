using AutoMapper.QueryableExtensions;

namespace Rs.Application.Features.Requests.QueryHandlers.GetRequests;

public class GetRequestsQueryHandler(IDataContext context,
    IUser user,
    IMapper mapper)
    : IQueryHandler<GetRequestsQuery, List<GetRequestsResponse>>
{
    public async Task<Result<List<GetRequestsResponse>>> Handle(
        GetRequestsQuery requests,
        CancellationToken cancellationToken)
    {
        var data = await context.Requests
            .AsNoTracking()
            .Where(req => req.CreatedBy == user.Id)
            .ProjectTo<GetRequestsResponse>(mapper.ConfigurationProvider)
            .Take(10)
            .ToListAsync(cancellationToken);

        return data;
    }
}
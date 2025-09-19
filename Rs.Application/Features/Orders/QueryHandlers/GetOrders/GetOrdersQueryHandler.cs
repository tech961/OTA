namespace Rs.Application.Features.Orders.QueryHandlers.GetOrders;

public class GetOrdersQueryHandler(
    IDataContext context,
    IMapper mapper,
    IUser user)
    : IQueryHandler<GetOrdersQuery, List<GetOrdersResponse>>
{
    public async Task<Result<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await context.Orders.AsNoTracking()
            .Include(o => o.Items)
            .Where(o => o.UserId == user.Id)
            .OrderByDescending(o => o.OrderDateUtc)
            .ToListAsync(cancellationToken);

        var response = mapper.Map<List<GetOrdersResponse>>(orders);
        return response;
    }
}

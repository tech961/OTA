namespace Rs.Application.Features.Carts.QueryHandlers.GetCart;

public class GetCartQueryHandler(
    IDataContext context,
    IMapper mapper,
    IUser user)
    : IQueryHandler<GetCartQuery, GetCartResponse>
{
    public async Task<Result<GetCartResponse>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts.AsNoTracking()
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == CartStatus.Active, cancellationToken);

        if (cart is null)
        {
            return Result.Failure<GetCartResponse>(CartErrors.NotFound);
        }

        var response = mapper.Map<GetCartResponse>(cart);
        return response;
    }
}

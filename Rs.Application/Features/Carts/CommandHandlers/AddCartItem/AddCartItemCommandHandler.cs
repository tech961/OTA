namespace Rs.Application.Features.Carts.CommandHandlers.AddCartItem;

public class AddCartItemCommandHandler(
    IDataContext context,
    IUser user)
    : ICommandHandler<AddCartItemCommand, AddCartItemResponse>
{
    public async Task<Result<AddCartItemResponse>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == CartStatus.Active, cancellationToken);

        if (cart is null)
        {
            cart = new Cart
            {
                Id = Guid.NewGuid(),
                UserId = user.Id!.Value,
                Status = CartStatus.Active,
            };
            await context.Carts.AddAsync(cart, cancellationToken);
        }

        var product = await context.Products.FindAsync(new object?[] { request.ProductId }, cancellationToken);
        if (product is null)
        {
            return Result.Failure<AddCartItemResponse>(CartErrors.ProductNotFound);
        }

        var item = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
        if (item is null)
        {
            item = new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = product.DiscountPrice ?? product.Price,
                AddedAtUtc = DateTimeOffset.UtcNow
            };
            cart.Items.Add(item);
        }
        else
        {
            item.Quantity += request.Quantity;
        }

        await context.SaveChangesAsync(cancellationToken);

        var response = new AddCartItemResponse(cart.Id, item.Id);
        return response;
    }
}

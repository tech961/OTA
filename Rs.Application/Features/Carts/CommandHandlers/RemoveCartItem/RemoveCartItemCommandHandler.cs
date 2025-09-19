namespace Rs.Application.Features.Carts.CommandHandlers.RemoveCartItem;

public class RemoveCartItemCommandHandler(
    IDataContext context,
    IUser user)
    : ICommandHandler<RemoveCartItemCommand>
{
    public async Task<Result> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await context.CartItems
            .Include(ci => ci.Cart)
            .FirstOrDefaultAsync(ci => ci.Id == request.CartItemId && ci.Cart.UserId == user.Id, cancellationToken);

        if (cartItem is null)
        {
            return Result.Failure(CartErrors.ItemNotFound);
        }

        context.CartItems.Remove(cartItem);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

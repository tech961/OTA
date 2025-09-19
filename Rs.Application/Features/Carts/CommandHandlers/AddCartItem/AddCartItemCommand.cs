namespace Rs.Application.Features.Carts.CommandHandlers.AddCartItem;

public sealed record AddCartItemCommand(
    Guid ProductId,
    int Quantity
) : ICommand<AddCartItemResponse>;

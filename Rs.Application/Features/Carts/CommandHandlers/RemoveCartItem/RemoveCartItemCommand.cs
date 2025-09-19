namespace Rs.Application.Features.Carts.CommandHandlers.RemoveCartItem;

public sealed record RemoveCartItemCommand(Guid CartItemId) : ICommand;

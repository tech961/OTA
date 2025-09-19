namespace Rs.Application.Features.Carts.QueryHandlers.GetCart;

public sealed record GetCartResponse(
    Guid Id,
    CartStatus Status,
    List<GetCartItemResponse> Items);

public sealed record GetCartItemResponse(
    Guid Id,
    Guid ProductId,
    int Quantity,
    decimal UnitPrice);

namespace Rs.Application.Features.Orders.QueryHandlers.GetOrders;

public sealed record GetOrderItemResponse(Guid ProductId, int Quantity, decimal UnitPrice);

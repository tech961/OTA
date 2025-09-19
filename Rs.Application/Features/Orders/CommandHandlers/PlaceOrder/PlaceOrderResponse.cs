namespace Rs.Application.Features.Orders.CommandHandlers.PlaceOrder;

public sealed record PlaceOrderResponse(Guid OrderId, string OrderNumber);

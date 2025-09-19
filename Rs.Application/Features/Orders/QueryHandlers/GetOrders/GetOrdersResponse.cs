namespace Rs.Application.Features.Orders.QueryHandlers.GetOrders;

public sealed record GetOrdersResponse(
    Guid Id,
    string OrderNumber,
    DateTimeOffset OrderDateUtc,
    OrderStatus Status,
    decimal TotalAmount,
    decimal DiscountAmount,
    OrderAddressResponse ShippingAddress,
    OrderAddressResponse BillingAddress,
    List<GetOrderItemResponse> Items);

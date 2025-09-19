namespace Rs.Application.Features.Orders.CommandHandlers.PlaceOrder;

public sealed record PlaceOrderAddress(
    string FirstName,
    string LastName,
    string Phone,
    string Country,
    string City,
    string Line1,
    string? Line2,
    string PostalCode);

public sealed record PlaceOrderCommand(
    PlaceOrderAddress ShippingAddress,
    PlaceOrderAddress BillingAddress
) : ICommand<PlaceOrderResponse>;

namespace Rs.Application.Features.Orders.QueryHandlers.GetOrders;

public sealed record OrderAddressResponse(
    string FirstName,
    string LastName,
    string Phone,
    string Country,
    string City,
    string Line1,
    string? Line2,
    string PostalCode);

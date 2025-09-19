namespace Rs.Application.Features.Orders;

public static class OrderErrors
{
    public static readonly Error CartEmpty = new(
        HttpErrorCode.BadRequest,
        "Cart.Empty",
        "Cart is empty.");

    public static readonly Error NotFound = new(
        HttpErrorCode.NotFound,
        "Order.NotFound",
        "Order not found.");
}

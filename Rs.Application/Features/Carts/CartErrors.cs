namespace Rs.Application.Features.Carts;

public static class CartErrors
{
    public static readonly Error NotFound = new(
        HttpErrorCode.NotFound,
        "Cart.NotFound",
        "Cart not found.");

    public static readonly Error ProductNotFound = new(
        HttpErrorCode.NotFound,
        "Product.NotFound",
        "Product not found.");

    public static readonly Error ItemNotFound = new(
        HttpErrorCode.NotFound,
        "CartItem.NotFound",
        "Cart item not found.");
}

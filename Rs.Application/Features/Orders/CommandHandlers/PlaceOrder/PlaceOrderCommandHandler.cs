using Rs.Application.Features.Carts;
using Rs.Domain.Aggregates.PetShop.ValueObjects;

namespace Rs.Application.Features.Orders.CommandHandlers.PlaceOrder;

public class PlaceOrderCommandHandler(
    IDataContext context,
    IUser user)
    : ICommandHandler<PlaceOrderCommand, PlaceOrderResponse>
{
    public async Task<Result<PlaceOrderResponse>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == user.Id && c.Status == CartStatus.Active, cancellationToken);

        if (cart is null)
        {
            return Result.Failure<PlaceOrderResponse>(CartErrors.NotFound);
        }

        if (cart.Items.Count == 0)
        {
            return Result.Failure<PlaceOrderResponse>(OrderErrors.CartEmpty);
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = user.Id!.Value,
            OrderNumber = $"ORD-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}",
            OrderDateUtc = DateTimeOffset.UtcNow,
            Status = OrderStatus.Pending,
            TotalAmount = cart.Items.Sum(i => i.UnitPrice * i.Quantity),
            DiscountAmount = 0,
            ShippingAddress = new Address(
                request.ShippingAddress.FirstName,
                request.ShippingAddress.LastName,
                request.ShippingAddress.Phone,
                request.ShippingAddress.Country,
                request.ShippingAddress.City,
                request.ShippingAddress.Line1,
                request.ShippingAddress.Line2,
                request.ShippingAddress.PostalCode),
            BillingAddress = new Address(
                request.BillingAddress.FirstName,
                request.BillingAddress.LastName,
                request.BillingAddress.Phone,
                request.BillingAddress.Country,
                request.BillingAddress.City,
                request.BillingAddress.Line1,
                request.BillingAddress.Line2,
                request.BillingAddress.PostalCode),
            Items = cart.Items.Select(ci => new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                UnitPrice = ci.UnitPrice
            }).ToList()
        };

        await context.Orders.AddAsync(order, cancellationToken);

        cart.Status = CartStatus.CheckedOut;
        cart.Items.Clear();

        await context.SaveChangesAsync(cancellationToken);

        var response = new PlaceOrderResponse(order.Id, order.OrderNumber);
        return response;
    }
}

namespace Rs.Application.Features.Orders.CommandHandlers.PlaceOrder;

public class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidator()
    {
        RuleFor(x => x.ShippingAddress).NotNull();
        RuleFor(x => x.BillingAddress).NotNull();

        RuleForEach(x => new[] { x.ShippingAddress, x.BillingAddress }).ChildRules(address =>
        {
            address.RuleFor(a => a.FirstName).NotEmpty();
            address.RuleFor(a => a.LastName).NotEmpty();
            address.RuleFor(a => a.Phone).NotEmpty();
            address.RuleFor(a => a.Country).NotEmpty();
            address.RuleFor(a => a.City).NotEmpty();
            address.RuleFor(a => a.Line1).NotEmpty();
            address.RuleFor(a => a.PostalCode).NotEmpty();
        });
    }
}

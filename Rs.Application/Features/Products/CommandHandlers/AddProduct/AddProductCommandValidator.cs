using System.Text.RegularExpressions;

namespace Rs.Application.Features.Products.CommandHandlers.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().MinimumLength(3).MaximumLength(200);

        RuleFor(c => c.Slug)
            .NotEmpty()
            .Matches("^[a-z0-9-]+$");

        RuleFor(c => c.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(c => c.DiscountPrice)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(c => c.Price)
            .When(c => c.DiscountPrice.HasValue);

        RuleFor(c => c.StockQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(c => c.SKU)
            .NotEmpty()
            .MaximumLength(64);
    }
}

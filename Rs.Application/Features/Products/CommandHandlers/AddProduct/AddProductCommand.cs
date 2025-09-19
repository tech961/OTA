namespace Rs.Application.Features.Products.CommandHandlers.AddProduct;

public sealed record AddProductCommand(
    string Name,
    string Slug,
    string Description,
    decimal Price,
    decimal? DiscountPrice,
    int StockQuantity,
    string SKU,
    string? Barcode,
    ProductCondition Condition,
    ProductStatus Status,
    Guid CategoryId
) : ICommand<AddProductResponse>;

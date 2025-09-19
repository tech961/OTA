namespace Rs.Application.Features.Products.QueryHandlers.GetProducts;

public sealed class GetProductsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public ProductStatus Status { get; set; }
}

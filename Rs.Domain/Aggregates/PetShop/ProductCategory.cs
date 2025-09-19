namespace Rs.Domain.Aggregates.PetShop;

public class ProductCategory : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public ProductCategory? ParentCategory { get; set; }

    public List<ProductCategory> Children { get; set; } = new();
    public List<Product> Products { get; set; } = new();
}

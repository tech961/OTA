using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int StockQuantity { get; set; }
    public string SKU { get; set; } = null!;
    public string? Barcode { get; set; }
    public ProductCondition Condition { get; set; }
    public ProductStatus Status { get; set; }
    public bool IsDeleted { get; set; }
    public byte[] ConcurrencyStamp { get; set; } = Array.Empty<byte>();

    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; } = null!;

    public List<ProductImage> Images { get; set; } = new();
    public List<ProductAttribute> Attributes { get; set; } = new();
    public List<ProductSuitability> Suitabilities { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public List<InventoryTransaction> InventoryTransactions { get; set; } = new();
    public List<OrderItem> OrderItems { get; set; } = new();
}

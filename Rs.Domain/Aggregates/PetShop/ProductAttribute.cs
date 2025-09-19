namespace Rs.Domain.Aggregates.PetShop;

public class ProductAttribute : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}

namespace Rs.Domain.Aggregates.PetShop;

public class Wishlist : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}

using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class Cart : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public CartStatus Status { get; set; }

    public List<CartItem> Items { get; set; } = new();
}

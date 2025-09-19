using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class InventoryTransaction : BaseAuditableEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int ChangeQuantity { get; set; }
    public InventoryReason Reason { get; set; }
    public string? Note { get; set; }
}

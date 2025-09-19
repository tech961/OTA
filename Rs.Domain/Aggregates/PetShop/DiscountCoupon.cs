using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class DiscountCoupon : BaseAuditableEntity
{
    public string Code { get; set; } = null!;
    public DiscountType Type { get; set; }
    public decimal Value { get; set; }
    public DateTimeOffset? ExpiryDateUtc { get; set; }
    public decimal? MinOrderAmount { get; set; }
    public int? MaxUsage { get; set; }
    public int UsedCount { get; set; }
}

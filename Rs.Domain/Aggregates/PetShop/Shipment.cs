using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class Shipment : BaseAuditableEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string? TrackingNumber { get; set; }
    public string Carrier { get; set; } = null!;
    public ShipmentStatus Status { get; set; }
    public DateTimeOffset? EstimatedDeliveryDateUtc { get; set; }
    public DateTimeOffset? DeliveredAtUtc { get; set; }
}

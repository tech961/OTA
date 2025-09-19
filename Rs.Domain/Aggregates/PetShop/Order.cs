using Rs.Domain.Aggregates.PetShop.ValueObjects;
using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class Order : BaseAuditableEntity
{
    public Order()
    {
        
    }
    public Guid UserId { get; set; }
    public string OrderNumber { get; set; } = null!;
    public DateTimeOffset OrderDateUtc { get; set; }
    public OrderStatus Status { get; set; } 
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public Guid? PaymentId { get; set; }
    public Payment? Payment { get; set; }
    public Shipment? Shipment { get; set; }
    public Address ShippingAddress { get; set; } = null!;
    public Address BillingAddress { get; set; } = null!;

    public List<OrderItem> Items { get; set; } = new();
}

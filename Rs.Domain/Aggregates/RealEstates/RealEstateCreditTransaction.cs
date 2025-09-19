namespace Rs.Domain.Aggregates.RealEstates;

public class RealEstateCreditTransaction : BaseEntity
{
    public Guid RealEstateId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? PaymentDateUtc { get; private set; }
    
    public PaymentStatusEnum PaymentStatus { get; private set; }
    
    public decimal Price { get; private set; }

    public int CreditCount { get; private set; }

    public RealEstate RealEstate { get; private set; }
}
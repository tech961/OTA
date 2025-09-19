namespace Rs.Domain.Aggregates.RealEstates;

public class RealEstatePerson 
{
    public Guid UserId { get; private set; }
    public Guid RealEstateId { get; private set; }

    public RealEstate RealEstate { get; private set; }

    public User Users { get; private set; }
}
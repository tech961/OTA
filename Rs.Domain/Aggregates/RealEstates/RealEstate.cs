using Rs.Domain.Aggregates.Provinces;

namespace Rs.Domain.Aggregates.RealEstates;

public class RealEstate : BaseAuditableEntity
{
    private readonly List<RealEstatePerson> _realEstatePerson = [];
    private readonly List<RealEstateTrackingRequest> _realEstateTrackingRequests = [];
    public string Name { get; private set; }

    public string Loaction { get; private set; }

    public Guid NeighborhoodId { get; private set; }

    public Guid ManagerId { get; private set; }

    public Guid? LogoId { get; private set; }

    public int Credit { get; private set; }
    
    public Neighborhood Neighborhood { get; private set; }

    public User Manager { get; private set; }

    public IReadOnlyCollection<RealEstatePerson> RealEstatePersons => _realEstatePerson;
    
    public IReadOnlyCollection<RealEstateTrackingRequest> RealEstateTrackingRequests => _realEstateTrackingRequests;
}
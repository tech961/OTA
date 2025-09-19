using Rs.Domain.Aggregates.Requests;

namespace Rs.Domain.Aggregates.RealEstates;

public class RealEstateTrackingRequest : BaseEntity
{
    public Guid RequestId { get; private set; }

    public Guid RealEstateId { get; private set; }

    public Guid? TrackingById { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ResponseDateTime { get; private set; }

    public DateTime ExpiredTime { get; private set; }

    public RealEstateResponseEnum Response { get; private set; }

    public string? ResponseDescription { get; private set; }

    public Request? Request { get; private set; }

    public RealEstate? RealEstate { get; private set; }

    public User? TrackingBy  { get; private set; }
}
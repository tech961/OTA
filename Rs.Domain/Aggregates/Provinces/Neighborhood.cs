namespace Rs.Domain.Aggregates.Provinces;

public class Neighborhood : BaseEntity
{
    public string Title { get; private set; }

    public Guid DistrictId { get; private set; }

    public bool IsActive { get; private set; }

    public District District { get; private set; }

    public static Neighborhood AddNeighborhood(District district, string title)
    {
        var neighborhood = new Neighborhood()
        {
            District = district,
            Title = title
        };

        return neighborhood;
    }
}
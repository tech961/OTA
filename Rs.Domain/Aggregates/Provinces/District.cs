namespace Rs.Domain.Aggregates.Provinces;

public class District : BaseEntity
{
    private readonly List<Neighborhood> _neighborhoods = [];
    
    public string Title { get; private set; }

    public Guid CityId { get; private set; }

    public bool IsActive { get; private set; }

    public City City { get; private set; }

    public IReadOnlyCollection<Neighborhood> Neighborhoods => _neighborhoods;
    
    public static District AddDistrict(City city, string title)
    {
        var district = new District()
        {
            City = city,
            Title = title
        };

        return district;
    }
    
 
}
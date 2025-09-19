namespace Rs.Domain.Aggregates.Provinces;

public class City : BaseEntity
{
    private readonly List<District> _districts = [];

    public string Title { get; private set; }

    public Guid ProvinceId { get; private set; }

    public bool IsActive { get; private set; }

    public Province Province { get; private set; }

    public IReadOnlyCollection<District> Districts => _districts;

    public static City AddCity(Province province, string title)
    {
        var city = new City()
        {
            Province = province,
            Title = title
        };

        return city;
    }
    
    public void AddDistricts(List<District> districts)
    {
        _districts.AddRange(districts);
    }
}
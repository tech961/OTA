namespace Rs.Domain.Aggregates.Provinces;

public class Province : BaseEntity
{
    private readonly List<City> _cities = [];

    public string Title { get; private set; }

    public bool IsActive { get; private set; }

    public IReadOnlyCollection<City> Cities => _cities;

    public static Province AddProvince(string title)
    {
        var province = new Province()
        {
            Title = title
        };

        return province;
    }

    public void AddCities(List<City> cities)
    {
        _cities.AddRange(cities);
    }

    public void AddDistricts(List<District> districts)
    {
        var city = _cities.FirstOrDefault();

        if (city == null)
        {
            return;
        }
        
        city.AddDistricts(districts);
    }
}
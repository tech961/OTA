namespace Rs.Application.Features.Provinces.CommandHandlers.ImportCityFromExcel;

public class CityGroupDataDto
{
    public string Province { get; set; }

    public List<CityItem> CityItems { get; set; }
}

public class CityItem(string title)
{
    public string Title { get; set; } = title;
}
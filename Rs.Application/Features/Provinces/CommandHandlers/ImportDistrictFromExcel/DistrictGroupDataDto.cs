namespace Rs.Application.Features.Provinces.CommandHandlers.ImportDistrictFromExcel;

public class DistrictGroupDataDto
{
    public string City { get; set; }

    public List<DistrictItem> DistrictItems { get; set; }
}

public class DistrictItem(string title)
{
    public string Title { get; set; } = title;
}
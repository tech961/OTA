namespace Rs.Application.Features.Provinces.CommandHandlers.ImportNeighborhoodFromExcel;

public class NeighborhoodGroupDataDto
{
    public string District { get; set; }

    public List<NeighborhoodItem> NeighborhoodItems { get; set; }
}

public class NeighborhoodItem(string title)
{
    public string Title { get; set; } = title;
}
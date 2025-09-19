using Rs.Domain.Shared.CustomAttributes;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportNeighborhoodFromExcel;

public class NeighborhoodMapDto
{
    [ExcelColumn("title")]
    public string Title { get; set; }

    [ExcelColumn("district")]
    public string District { get; set; }
}
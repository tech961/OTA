using Rs.Domain.Shared.CustomAttributes;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportDistrictFromExcel;

public class DistrictMapDto
{
    [ExcelColumn("title")]
    public string Title { get; set; }

    [ExcelColumn("city")]
    public string City { get; set; }
}
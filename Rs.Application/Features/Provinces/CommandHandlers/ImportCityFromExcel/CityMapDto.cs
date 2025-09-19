using Rs.Domain.Shared.CustomAttributes;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportCityFromExcel;

public class CityMapDto
{
    [ExcelColumn("title")]
    public string Title { get; set; }

    [ExcelColumn("province")]
    public string Province { get; set; }
}
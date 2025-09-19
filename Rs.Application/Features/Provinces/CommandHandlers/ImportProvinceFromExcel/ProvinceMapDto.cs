using Rs.Domain.Shared.CustomAttributes;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportProvinceFromExcel;

public class ProvinceMapDto
{
    [ExcelColumn("title")]
    public string Title { get; set; }
}
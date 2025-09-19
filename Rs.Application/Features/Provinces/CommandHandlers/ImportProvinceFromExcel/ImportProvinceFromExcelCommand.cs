namespace Rs.Application.Features.Provinces.CommandHandlers.ImportProvinceFromExcel;

public sealed record ImportProvinceFromExcelCommand(IFormFile ExcelFile) : ICommand<bool>;

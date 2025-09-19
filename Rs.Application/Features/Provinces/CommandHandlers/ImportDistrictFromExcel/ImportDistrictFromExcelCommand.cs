namespace Rs.Application.Features.Provinces.CommandHandlers.ImportDistrictFromExcel;

public sealed record ImportDistrictFromExcelCommand(IFormFile ExcelFile) : ICommand<bool>;

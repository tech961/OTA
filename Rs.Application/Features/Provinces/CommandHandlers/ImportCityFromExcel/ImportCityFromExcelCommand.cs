namespace Rs.Application.Features.Provinces.CommandHandlers.ImportCityFromExcel;

public sealed record ImportCityFromExcelCommand(IFormFile ExcelFile) : ICommand<bool>;

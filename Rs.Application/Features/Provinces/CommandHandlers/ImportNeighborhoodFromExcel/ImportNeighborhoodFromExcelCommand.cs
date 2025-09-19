namespace Rs.Application.Features.Provinces.CommandHandlers.ImportNeighborhoodFromExcel;

public sealed record ImportNeighborhoodFromExcelCommand(IFormFile ExcelFile) : ICommand<bool>;

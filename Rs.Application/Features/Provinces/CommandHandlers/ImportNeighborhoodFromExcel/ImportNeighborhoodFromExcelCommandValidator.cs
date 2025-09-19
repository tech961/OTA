namespace Rs.Application.Features.Provinces.CommandHandlers.ImportNeighborhoodFromExcel;

public class ImportNeighborhoodFromExcelCommandValidator
    : AbstractValidator<ImportNeighborhoodFromExcelCommand>
{
    public ImportNeighborhoodFromExcelCommandValidator()
    {
        RuleFor(x => x.ExcelFile)
            .NotNull()
            .WithMessage("File is required.")
            .Must(ValidatorUtility.BeAnExcelFile)
            .WithMessage("Only .xlsx files are allowed.");
    }
}
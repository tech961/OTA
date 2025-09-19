namespace Rs.Application.Features.Provinces.CommandHandlers.ImportCityFromExcel;

public class ImportCityFromExcelCommandValidator
    : AbstractValidator<ImportCityFromExcelCommand>
{
    public ImportCityFromExcelCommandValidator()
    {
        RuleFor(x => x.ExcelFile)
            .NotNull()
            .WithMessage("File is required.")
            .Must(ValidatorUtility.BeAnExcelFile)
            .WithMessage("Only .xlsx files are allowed.");
    }
}
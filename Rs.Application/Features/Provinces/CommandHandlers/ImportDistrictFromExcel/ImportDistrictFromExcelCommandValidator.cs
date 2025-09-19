namespace Rs.Application.Features.Provinces.CommandHandlers.ImportDistrictFromExcel;

public class ImportDistrictFromExcelCommandValidator
    : AbstractValidator<ImportDistrictFromExcelCommand>
{
    public ImportDistrictFromExcelCommandValidator()
    {
        RuleFor(x => x.ExcelFile)
            .NotNull()
            .WithMessage("File is required.")
            .Must(ValidatorUtility.BeAnExcelFile)
            .WithMessage("Only .xlsx files are allowed.");
    }
}
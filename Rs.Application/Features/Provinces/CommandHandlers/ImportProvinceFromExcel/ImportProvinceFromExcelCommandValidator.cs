namespace Rs.Application.Features.Provinces.CommandHandlers.ImportProvinceFromExcel;

public class ImportProvinceFromExcelCommandValidator
    : AbstractValidator<ImportProvinceFromExcelCommand>
{
    public ImportProvinceFromExcelCommandValidator()
    {
        RuleFor(x => x.ExcelFile)
            .NotNull()
            .WithMessage("File is required.")
            .Must(ValidatorUtility.BeAnExcelFile)
            .WithMessage("Only .xlsx files are allowed.");
    }
}
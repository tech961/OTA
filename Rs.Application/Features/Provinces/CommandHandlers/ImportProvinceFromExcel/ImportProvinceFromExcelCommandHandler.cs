using Rs.Domain.Aggregates.Provinces;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportProvinceFromExcel;

public class ImportProvinceFromExcelCommandHandler(
    IDataContext context,
    IExcelService excelService)
    : ICommandHandler<ImportProvinceFromExcelCommand, bool>
{
    public async Task<Result<bool>> Handle(ImportProvinceFromExcelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var convertedData = excelService
                .ImportData<ProvinceMapDto>(request.ExcelFile.OpenReadStream());

            if (convertedData.IsFailure)
            {
                return Result.Failure<bool>(convertedData.Error);
            }
            
            foreach (var province in convertedData
                         .Value.Select(item => Province.AddProvince(item.Title)))
            {
                await context.Provinces.AddAsync(province, cancellationToken);
            }

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (Exception e)
        {
            return Result.Failure<bool>(ProvinceError.CanNotConvertExcel);
        }
    }
}
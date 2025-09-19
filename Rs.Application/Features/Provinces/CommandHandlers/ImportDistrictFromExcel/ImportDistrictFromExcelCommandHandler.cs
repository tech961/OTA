using Rs.Domain.Aggregates.Provinces;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportDistrictFromExcel;

public class ImportDistrictFromExcelCommandHandler(
    IDataContext context,
    IExcelService excelService)
    : ICommandHandler<ImportDistrictFromExcelCommand, bool>
{
    public async Task<Result<bool>> Handle(
        ImportDistrictFromExcelCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var convertedData = excelService
                .ImportData<DistrictMapDto>(request.ExcelFile.OpenReadStream());

            if (convertedData.IsFailure)
            {
                return Result.Failure<bool>(convertedData.Error);
            }

            var cityGroupData = convertedData.Value
                .GroupBy(cd => cd.City)
                .Select(gp => new DistrictGroupDataDto()
                {
                    City = gp.Key,
                    DistrictItems = gp.Select(x => new DistrictItem(x.Title)).ToList()
                });

            foreach (var itemGroup in cityGroupData)
            {
                var city = await context.Cities
                    .FirstOrDefaultAsync(c => c.Title.Equals(itemGroup.City), cancellationToken);

                if (city == null) continue;

                var districts = itemGroup
                    .DistrictItems
                    .Select(district => District.AddDistrict(city, district.Title))
                    .ToList();

                await context.Districts.AddRangeAsync(districts, cancellationToken);
            }

            return await context.SaveChangesAsync(cancellationToken) > 1;
        }
        catch (Exception)
        {
            return Result.Failure<bool>(ProvinceError.CanNotConvertExcel);
        }
    }
}
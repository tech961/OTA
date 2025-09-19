using Rs.Domain.Aggregates.Provinces;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportCityFromExcel;

public class ImportCityFromExcelCommandHandler(
    IDataContext context,
    IExcelService excelService)
    : ICommandHandler<ImportCityFromExcelCommand, bool>
{
    public async Task<Result<bool>> Handle(ImportCityFromExcelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var convertedData = excelService.ImportData<CityMapDto>(request.ExcelFile.OpenReadStream());

            if (convertedData.IsFailure)
            {
                return Result.Failure<bool>(convertedData.Error);
            }

            var provincesGroupData = convertedData.Value
                .GroupBy(cd => cd.Province)
                .Select(gp => new CityGroupDataDto()
                {
                    Province = gp.Key,
                    CityItems = gp.Select(x => new CityItem(x.Title)).ToList()
                });

            foreach (var itemGroup in provincesGroupData)
            {
                var provinceResult = await context.Provinces
                    .FirstOrDefaultAsync(pv => pv.Title.Equals(itemGroup.Province), cancellationToken);

                if (provinceResult == null) continue;

                var cities = itemGroup
                    .CityItems
                    .Select(city => City.AddCity(provinceResult, city.Title))
                    .ToList();

                await context.Cities.AddRangeAsync(cities, cancellationToken);
            }

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (Exception e)
        {
            return Result.Failure<bool>(ProvinceError.CanNotConvertExcel);
        }
    }
}
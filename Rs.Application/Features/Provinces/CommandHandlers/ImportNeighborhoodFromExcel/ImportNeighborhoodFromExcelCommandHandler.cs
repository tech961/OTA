using Rs.Domain.Aggregates.Provinces;

namespace Rs.Application.Features.Provinces.CommandHandlers.ImportNeighborhoodFromExcel;

public class ImportNeighborhoodFromExcelCommandHandler(
    IDataContext context,
    IExcelService excelService)
    : ICommandHandler<ImportNeighborhoodFromExcelCommand, bool>
{
    public async Task<Result<bool>> Handle(
        ImportNeighborhoodFromExcelCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var convertedData = excelService
                .ImportData<NeighborhoodMapDto>(request.ExcelFile.OpenReadStream());

            if (convertedData.IsFailure)
            {
                return Result.Failure<bool>(convertedData.Error);
            }

            var districtGroupData = convertedData.Value
                .GroupBy(cd => cd.District)
                .Select(gp => new NeighborhoodGroupDataDto()
                {
                    District = gp.Key,
                    NeighborhoodItems = gp.Select(x => new NeighborhoodItem(x.Title)).ToList()
                });

            foreach (var itemGroup in districtGroupData)
            {
                var district = await context.Districts
                    .FirstOrDefaultAsync(d => d.Title.Equals(itemGroup.District),cancellationToken);
                
                if (district == null) continue;

                var neighborhood = itemGroup
                    .NeighborhoodItems
                    .Select(n => Neighborhood.AddNeighborhood(district, n.Title))
                    .ToList();

                await context.Neighborhoods.AddRangeAsync(neighborhood, cancellationToken);
            }

            return await context.SaveChangesAsync(cancellationToken) > 1;
        }
        catch (Exception)
        {
            return Result.Failure<bool>(ProvinceError.CanNotConvertExcel);
        }
    }
}
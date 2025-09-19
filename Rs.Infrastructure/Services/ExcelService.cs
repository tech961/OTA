using System.Reflection;
using ClosedXML.Excel;
using Rs.Domain.Shared;
using Rs.Domain.Shared.CustomAttributes;

namespace Rs.Infrastructure.Services;

public class ExcelService : IExcelService
{
    public Result<List<T>> ImportData<T>(Stream excelStream) where T : new()
    {
        var dataList = new List<T>();

        using var workbook = new XLWorkbook(excelStream);
        var worksheet = workbook.Worksheet(1);
        var headerRow = worksheet.FirstRowUsed();
        var rows = worksheet
            .RowsUsed()
            .Skip(1)
            .ToList(); 

        if (headerRow == null || !headerRow.Cells().Any())
        {
            return Result.Failure<List<T>>(
                new Error(HttpErrorCode.BadRequest,
                    "ExcelConvert.NoColumns",
                    "The Excel file contains no columns."));
        }

        if (rows.Count == 0)
        {
            return Result.Failure<List<T>>(
                new Error(HttpErrorCode.BadRequest,
                    "ExcelConvert.NoRows",
                    "The Excel file contains no data rows."));
        }
        
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var columnMapping = new Dictionary<string, int>();

        foreach (var cell in headerRow.Cells())
        {
            columnMapping[cell.GetString()] = cell.Address.ColumnNumber;
        }

        foreach (var row in rows)
        {
            var data = new T();

            foreach (var prop in properties)
            {
                var columnName = prop.Name;

                var attribute = prop.GetCustomAttribute<ExcelColumnAttribute>();
                if (attribute != null)
                {
                    columnName = attribute.ColumnName;
                }

                if (!columnMapping.TryGetValue(columnName, out var columnIndex))
                {
                    return Result.Failure<List<T>>(
                        new Error(HttpErrorCode.BadRequest,
                            "ExcelConvert.CanNotConvert",
                            "Failed to convert Excel data to the specified object type"));
                }
                var cellValue = row.Cell(columnIndex).Value;

                var convertedValue = Convert.ChangeType(cellValue.GetText(), prop.PropertyType);
                if (!string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    prop.SetValue(data, convertedValue);
                }
            }

            dataList.Add(data);
        }

        return dataList;
    }
}

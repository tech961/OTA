namespace Rs.Application.Common.Interfaces;

public interface IExcelService
{
    Result<List<T>> ImportData<T>(Stream excelStream)
        where T : new();
}
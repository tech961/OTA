namespace Rs.Domain.Shared.CustomAttributes;

public class ExcelColumnAttribute(string columnName) : Attribute
{
    public string ColumnName { get; } = columnName;
}
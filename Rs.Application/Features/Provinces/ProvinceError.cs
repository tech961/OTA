namespace Rs.Application.Features.Provinces;

public static class ProvinceError
{
    public static readonly Error CanNotConvertExcel = new Error(
        HttpErrorCode.BadRequest,
        "City.CanNotConvertExcel",
        "Failed to convert Excel data to the specified object type.");
    
    public static readonly Error FileIsEmpty = new Error(
        HttpErrorCode.BadRequest,
        "City.FileIsEmpty",
        "The uploaded file is empty. Please provide a valid file for processing.");
}
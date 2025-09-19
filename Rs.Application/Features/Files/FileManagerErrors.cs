namespace Rs.Application.Features.Files;

public static class FileManagerErrors
{
    public static readonly Error FileNotFound = new Error(
        HttpErrorCode.NotFound,
        "FileManager.FileNotFound",
        "The specified file could not be found. Please check the file path and try again.");
}
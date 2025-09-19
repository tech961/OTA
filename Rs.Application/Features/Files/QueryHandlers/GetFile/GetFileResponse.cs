namespace Rs.Application.Features.Files.QueryHandlers.GetFile;

public class GetFileResponse(FileStream fileStream, string fileName)
{
    public FileStream FileStream { get; set; } = fileStream;

    public string FileName { get; set; } = fileName;

    public string MemeType = "application/octet-stream";
}
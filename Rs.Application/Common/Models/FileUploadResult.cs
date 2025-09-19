namespace Rs.Application.Common.Models;

public class FileUploadResult
{
    private FileUploadResult(string name, string contentType, string physicalPath)
    {
        Name = name;
        ContentType = contentType;
        PhysicalPath = physicalPath;
    }

    public string Name { get; set; }

    public string ContentType { get; set; }

    public string PhysicalPath { get; set; }

    public static FileUploadResult Add(string name,
        string contentType,
        string physicalPath)
    {
        var response = new FileUploadResult(name, contentType, physicalPath);

        return response;
    }
}
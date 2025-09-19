namespace Rs.Domain.Aggregates.Files;

public class FileManager : BaseAuditableEntity
{
    public string Name { get; private set; }

    public string ContentType { get; private set; }

    public string PhysicalPath { get; private set; }

    public static FileManager AddFile(string name, string contentType, string physicalPath)
    {
        var file = new FileManager()
        {
            Id = Guid.NewGuid(),
            Name = name,
            ContentType = contentType,
            PhysicalPath = physicalPath
        };

        return file;
    }
}
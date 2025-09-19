namespace Rs.Domain.Options;

public class FileUploadSettings
{
    public string[] AllowedExtensions { get; set; }
    public long MaxFileSize { get; set; }
    public string UploadFolder { get; set; }
    public string WriteTo { get; set; }
}
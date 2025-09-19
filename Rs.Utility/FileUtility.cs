using Microsoft.AspNetCore.Http;

namespace Rs.Utility;

public static class FileUtility
{
    public static string SafeFileName(IFormFile file)
    {
        var safeFileName =  Path.GetFileNameWithoutExtension(file.FileName)
            .Replace(" ", "_")
            .Replace("-", "_");
        
        var fileExtension = Path.GetExtension(file.FileName);
        var fileName = $"{safeFileName}_{Guid.NewGuid()}{fileExtension}";

        return fileName;
    }
}
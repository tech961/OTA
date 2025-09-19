using Rs.Application.Common.Models;

namespace Rs.Application.Common.Interfaces;

public interface IFileService
{
    Task<Result<FileUploadResult>> UploadFileAsync(IFormFile file, string writeTo);

    Result<FileStream> GetFile(string filePath);

    Result<bool> DeleteFile(string filePath);
}
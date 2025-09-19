using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Rs.Application.Common.Models;
using Rs.Domain.Shared;
using Rs.Infrastructure.Common.Errors;
using Rs.Utility;

namespace Rs.Infrastructure.Services;

public class FileService(IWebHostEnvironment hostEnvironment) : IFileService
{
    private readonly string rootPath = hostEnvironment.WebRootPath
                                      ?? hostEnvironment.ContentRootPath
                                      ?? Directory.GetCurrentDirectory();

    public async Task<Result<FileUploadResult>> UploadFileAsync(IFormFile file, string writeTo)
    {
        try
        {
            var fileName = FileUtility.SafeFileName(file);
            var directoryPath = Path.Combine(rootPath, writeTo);
            Directory.CreateDirectory(directoryPath);

            var path = Path.Combine(directoryPath, fileName);

            await using var fs = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fs);

            return FileUploadResult.Add(
                fileName,
                Path.GetExtension(file.FileName),
                Path.Combine(writeTo, fileName));
        }
        catch
        {
            return Result.Failure<FileUploadResult>(FileUploadError.CanNotUploadFile);
        }
    }

    public Result<FileStream> GetFile(string filePath)
    {
        try
        {
            var path = Path.Combine(rootPath, filePath);

            if (!File.Exists(path))
            {
                return Result.Failure<FileStream>(FileUploadError.NotExistFile);
            }

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
        catch
        {
            return Result.Failure<FileStream>(FileUploadError.CanNotUploadFile);
        }
    }

    public Result<bool> DeleteFile(string filePath)
    {
        try
        {
            var path = Path.Combine(rootPath, filePath);

            if (!File.Exists(path))
            {
                return Result.Failure<bool>(FileUploadError.NotExistFile);
            }

            File.Delete(path);
            return true;
        }
        catch
        {
            return Result.Failure<bool>(FileUploadError.CanNotUploadFile);
        }
    }
}

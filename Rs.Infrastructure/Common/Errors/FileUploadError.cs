using Rs.Domain.Shared;

namespace Rs.Infrastructure.Common.Errors;

public static class FileUploadError
{
    public static readonly Error CanNotUploadFile = new Error(
        HttpErrorCode.InternalServerError,
        "UploadFile.CanNotUploadFile",
        "The file could not be uploaded due to an internal server error." +
        " Please try again later or contact support if the problem persists.");
    
    public static readonly Error CanNotDeleteFile = new Error(
        HttpErrorCode.InternalServerError,
        "UploadFile.CanNotDeleteFile",
        "The system encountered an internal error while trying to delete the specified file." +
        " Please ensure the file exists and that you have the necessary permissions to delete it.");
    
    public static readonly Error NotExistFile = new Error(
        HttpErrorCode.BadRequest,
        "UploadFile.NotExistFile",
        "The file you are trying to access does not exist.");
}
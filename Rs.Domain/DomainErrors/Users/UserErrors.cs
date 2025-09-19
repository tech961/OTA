namespace Rs.Domain.DomainErrors.Users;

public static class UserErrors
{
    public static readonly Error UserNotFound = new Error(
        HttpErrorCode.NotFound,
        "User.UserNotFound",
        "The specified user could not be found in the system. Please check the user ID and try again.");
    
    public static readonly Error FailedDelete = new Error(
        HttpErrorCode.BadRequest,
        "User.UserNotFound",
        "Failed to delete the user. The specified user could not be found.");
}
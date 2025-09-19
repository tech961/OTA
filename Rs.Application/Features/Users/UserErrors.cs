namespace Rs.Application.Features.Users;

public static class UserErrors
{
    public static readonly Error UserNotFound = new Error(
        HttpErrorCode.NotFound,
        "User.UserNotFound",
        "The specified user could not be found in the system. Please check the user ID and try again.");

    public static readonly Error UserNotAuthorized = new Error(
        HttpErrorCode.NotFound,
        "User.UserNotAuthorized",
        "The user is not authorized to perform this action.");

}
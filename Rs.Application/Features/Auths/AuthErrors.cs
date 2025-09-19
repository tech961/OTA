namespace Rs.Application.Features.Auths;

public static class AuthErrors
{
    public static readonly Error CodeIsNotValid = new Error(
        HttpErrorCode.BadRequest,
        "Auth.NotValidRequest",
        "کد احراز هویت درست نمی باشد. لطقا دوباره تلاش کنید");
    
    public static readonly Error CreateUserFailed = new Error(
        HttpErrorCode.InternalServerError,
        "Auth.CreateUserFailed",
        "An unexpected error occurred while creating a new user." +
        " Please try again later or contact support if the issue persists");
}
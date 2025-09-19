namespace Rs.Api.Extensions;

public static class ResultExtensions
{
    public static ActionResult<T> ToActionResult<T>(this Result<T> result)
    {
        if (result is { IsFailure: false })
            return new OkObjectResult(result.Value);

        var error = result.Error;
        var apiError = new ErrorResponse
        {
            Status = (int)error.HttpCode!,
            StatusPhrase = error.HttpCode.ToString(),
            Timestamp = DateTime.Now,
            Errors = [new ErrorItem(result.Error.Code, result.Error.Message)]
        };

        return error.HttpCode switch
        {
            HttpErrorCode.BadRequest => new BadRequestObjectResult(apiError),
            HttpErrorCode.NotFound => new NotFoundObjectResult(apiError),
            HttpErrorCode.Forbidden => new UnauthorizedObjectResult(apiError),
            HttpErrorCode.InternalServerError => throw new Exception(error),
            _ => new ObjectResult(apiError),
        };
    }
}
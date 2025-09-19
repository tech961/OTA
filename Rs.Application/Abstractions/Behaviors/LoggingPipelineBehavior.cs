namespace Rs.Application.Abstractions.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(
        ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting request {@RequestName}, {@DateTimeUtc}, thread id {@ThreadId}",
            typeof(TRequest).Name,
            DateTime.UtcNow,
            Environment.CurrentManagedThreadId);

        var result = await next();

        if (result.IsFailure)
        {
            _logger.LogError(
                "Request failure {@RequestName}, {@Error}, {@DateTimeUtc}, thread id {@ThreadId}",
                typeof(TRequest).Name,
                result.Error,
                DateTime.UtcNow,
                Environment.CurrentManagedThreadId);
        }

        _logger.LogInformation(
            "Completed request {@RequestName}, {@DateTimeUtc}, thread id {@ThreadId} ",
            typeof(TRequest).Name,
            DateTime.UtcNow,
            Environment.CurrentManagedThreadId);

        return result;
    }
}
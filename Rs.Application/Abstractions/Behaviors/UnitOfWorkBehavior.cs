namespace Rs.Application.Abstractions.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UnitOfWorkBehavior<TRequest, TResponse>> _logger;

    public UnitOfWorkBehavior(
        IUnitOfWork unitOfWork,
        ILogger<UnitOfWorkBehavior<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var response = await next();

            if (response is Result result && result.IsFailure)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                return response;
            }

            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return response;
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Unhandled exception for request {RequestName}. Rolling back transaction.",
                typeof(TRequest).Name);

            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}


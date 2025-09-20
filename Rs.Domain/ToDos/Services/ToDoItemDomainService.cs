namespace Rs.Domain.ToDos.Services;

public class ToDoItemDomainService : IToDoItemDomainService
{
    private static readonly IReadOnlyDictionary<ToDoStatus, ToDoStatus[]> AllowedTransitions =
        new Dictionary<ToDoStatus, ToDoStatus[]>
        {
            { ToDoStatus.Pending, new[] { ToDoStatus.InProgress, ToDoStatus.Completed } },
            { ToDoStatus.InProgress, new[] { ToDoStatus.Completed } },
            { ToDoStatus.Completed, Array.Empty<ToDoStatus>() }
        };

    public Result ValidateStatusTransition(ToDoStatus currentStatus, ToDoStatus newStatus)
    {
        if (currentStatus == newStatus)
        {
            return Result.Success();
        }

        if (!AllowedTransitions.TryGetValue(currentStatus, out var allowedTransitions))
        {
            return Result.Failure(ToDoErrors.InvalidStatusTransition(currentStatus, newStatus));
        }

        return allowedTransitions.Contains(newStatus)
            ? Result.Success()
            : Result.Failure(ToDoErrors.InvalidStatusTransition(currentStatus, newStatus));
    }
}

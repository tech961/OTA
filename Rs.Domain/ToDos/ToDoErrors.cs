namespace Rs.Domain.ToDos;

public static class ToDoErrors
{
    public static Error NotFound(Guid id) => new(
        HttpErrorCode.NotFound,
        "ToDo.NotFound",
        $"To-do item with id '{id}' was not found.");

    public static Error InvalidStatusTransition(ToDoStatus current, ToDoStatus next) => new(
        HttpErrorCode.BadRequest,
        "ToDo.InvalidStatusTransition",
        $"Cannot change status from {current} to {next}.");
}

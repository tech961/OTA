namespace Rs.Application.ToDos.Commands.UpdateToDoItem;

public record UpdateToDoItemCommand(Guid Id, string Title, string? Description, ToDoStatus Status) : ICommand<ToDoItemDto>;

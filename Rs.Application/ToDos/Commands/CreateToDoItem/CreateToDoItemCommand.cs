namespace Rs.Application.ToDos.Commands.CreateToDoItem;

public record CreateToDoItemCommand(string Title, string? Description, ToDoStatus Status) : ICommand<ToDoItemDto>;

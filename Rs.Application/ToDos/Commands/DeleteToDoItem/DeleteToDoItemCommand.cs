namespace Rs.Application.ToDos.Commands.DeleteToDoItem;

public record DeleteToDoItemCommand(Guid Id) : ICommand;

namespace Rs.Application.ToDos.Models;

public record ToDoItemDto(Guid Id, string Title, string? Description, ToDoStatus Status);

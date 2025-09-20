using Rs.Domain.ToDos;

namespace Rs.Api.Contracts.ToDoItems.Requests;

public record UpdateToDoItemRequest(string Title, string? Description, ToDoStatus Status);

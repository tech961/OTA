using Rs.Domain.ToDos;

namespace Rs.Api.Contracts.ToDoItems.Requests;

public record CreateToDoItemRequest(string Title, string? Description, ToDoStatus Status);

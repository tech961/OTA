namespace Rs.Api.Contracts.ToDoItems.Responses;

public record ToDoItemResponse(Guid Id, string Title, string? Description, ToDoStatus Status);

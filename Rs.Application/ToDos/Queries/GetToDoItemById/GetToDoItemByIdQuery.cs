namespace Rs.Application.ToDos.Queries.GetToDoItemById;

public record GetToDoItemByIdQuery(Guid Id) : IQuery<ToDoItemDto>;

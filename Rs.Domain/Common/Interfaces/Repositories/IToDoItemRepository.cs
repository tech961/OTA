using Rs.Domain.ToDos;

namespace Rs.Domain.Common.Interfaces.Repositories;

public interface IToDoItemRepository
{
    Task AddAsync(ToDoItem toDoItem, CancellationToken cancellationToken = default);

    Task<ToDoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ToDoItem>> GetAllAsync(CancellationToken cancellationToken = default);

    void Update(ToDoItem toDoItem);

    void Remove(ToDoItem toDoItem);
}

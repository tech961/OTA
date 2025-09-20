using Rs.Domain.Common.Interfaces.Repositories;
using Rs.Domain.ToDos;
using Rs.Persistence.DbPersistence;

namespace Rs.Persistence.Repositories.ToDoItems;

public class ToDoItemRepository : IToDoItemRepository
{
    private readonly DataContext _context;

    public ToDoItemRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ToDoItem toDoItem, CancellationToken cancellationToken = default)
    {
        await _context.ToDoItems.AddAsync(toDoItem, cancellationToken);
    }

    public async Task<ToDoItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ToDoItems.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<ToDoItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.ToDoItems
            .AsNoTracking()
            .OrderBy(item => item.Title)
            .ToListAsync(cancellationToken);

        return items;
    }

    public void Update(ToDoItem toDoItem)
    {
        _context.ToDoItems.Update(toDoItem);
    }

    public void Remove(ToDoItem toDoItem)
    {
        _context.ToDoItems.Remove(toDoItem);
    }
}

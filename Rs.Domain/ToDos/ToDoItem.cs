using Rs.Domain.Primitives;

namespace Rs.Domain.ToDos;

public class ToDoItem : BaseEntity
{
    private ToDoItem()
    {
    }

    private ToDoItem(string title, string? description, ToDoStatus status)
    {
        Title = title;
        Description = description;
        Status = status;
    }

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public ToDoStatus Status { get; private set; }

    public static ToDoItem Create(string title, string? description, ToDoStatus status)
    {
        return new ToDoItem(title, description, status)
        {
            Id = Guid.NewGuid()
        };
    }

    public void UpdateDetails(string title, string? description)
    {
        Title = title;
        Description = description;
    }

    public void UpdateStatus(ToDoStatus status)
    {
        Status = status;
    }
}

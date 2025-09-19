using Rs.Domain.Aggregates.Blogs;

namespace Rs.Domain.Events.Blogs;

public class AddBlogEvent(Guid id) : IDomainEvent
{
    public Guid Id { get; init; } = id;
}
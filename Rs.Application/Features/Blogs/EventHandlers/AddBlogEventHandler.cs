using Rs.Domain.Events.Blogs;

namespace Rs.Application.Features.Blogs.EventHandlers;

public class AddBlogEventHandler(ILogger<AddBlogEventHandler> logger) : INotificationHandler<AddBlogEvent>
{
    public Task Handle(AddBlogEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Add blog Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
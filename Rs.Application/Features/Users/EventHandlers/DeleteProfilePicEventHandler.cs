using Rs.Domain.Events.FileManagers;

namespace Rs.Application.Features.Users.EventHandlers;

public class DeleteProfilePicEventHandler(
    IDataContext context,
    IFileService fileService,
    ILogger<DeleteProfilePicEventHandler> logger)
    : INotificationHandler<DeleteCurrentProfilePicEvent>
{
    public async Task Handle(DeleteCurrentProfilePicEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteProfilePicEvent");
        var file = await context.FileManagers
            .SingleOrDefaultAsync(fm => fm.Id == notification.FileId, cancellationToken);

        if (file == null)
        {
            return;
        }

        var deleteResponse = fileService.DeleteFile(file.PhysicalPath);
        if (deleteResponse.IsSuccess)
        {
            context.FileManagers.Remove(file);
        }
        
        logger.LogInformation("Done DeleteProfilePicEvent");
    }
}
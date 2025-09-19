namespace Rs.Domain.Events.FileManagers;

public sealed record DeleteCurrentProfilePicEvent(Guid? FileId) : IDomainEvent;
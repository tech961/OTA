namespace Rs.Application.Features.Files.QueryHandlers.GetFile;

public sealed record GetFileQuery(Guid FileId) : IQuery<GetFileResponse>;

namespace Rs.Application.Features.Files.QueryHandlers.GetFile;

public class GetFileQueryHandler(IDataContext context,
    IFileService fileService)
    : IQueryHandler<GetFileQuery, GetFileResponse>
{
    public async Task<Result<GetFileResponse>> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        var file = await context.FileManagers
            .AsNoTracking()
            .SingleOrDefaultAsync(fm => fm.Id == request.FileId, cancellationToken);

        if (file == null)
        {
            return Result.Failure<GetFileResponse>(FileManagerErrors.FileNotFound);
        }

        var fileStreamResult = fileService.GetFile(file.PhysicalPath);

        if (fileStreamResult.IsFailure)
        {
            return Result.Failure<GetFileResponse>(fileStreamResult.Error);
        }
        
        return new GetFileResponse(fileStreamResult.Value, file.Name);
    }
}
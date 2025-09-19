using Rs.Application.Features.Files.QueryHandlers.GetFile;
using Rs.Application.Features.Requests.QueryHandlers.GetRequests;

namespace Rs.Api.Controllers;

[Authorize]
public class FileManagerController : BaseController
{
    [HttpGet("{fileId:guid}")]
    public async Task<ActionResult<GetFileResponse>> DownloadFile([FromRoute] Guid fileId,
        CancellationToken cancellationToken)
    {
        var query = new GetFileQuery(fileId);
        var response = await Mediator.Send(query, cancellationToken);

        if (response.IsFailure)
        {
            return response.ToActionResult();
        }

        var fileData = response.Value;
        return File(fileData.FileStream, fileData.MemeType, fileData.FileName);
    }
}
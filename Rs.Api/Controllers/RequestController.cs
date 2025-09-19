using Rs.Application.Features.Requests.CommandHandlers.AddRequest;
using Rs.Application.Features.Requests.QueryHandlers;
using Rs.Application.Features.Requests.QueryHandlers.GetRequests;

namespace Rs.Api.Controllers;

[Authorize]
public class RequestController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<GetRequestsResponse>>> GetRequests(
        CancellationToken cancellationToken)
    {
        var query = new GetRequestsQuery();

        var response = await Mediator.Send(query, cancellationToken);

        return response.ToActionResult();
    }
    
    [HttpPost]
    public async Task<ActionResult<AddRequestResponse>> AddRequest(
        [FromBody] AddRequestCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }
}
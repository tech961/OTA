using Rs.Application.Features.Orders.CommandHandlers.PlaceOrder;
using Rs.Application.Features.Orders.QueryHandlers.GetOrders;

namespace Rs.Api.Controllers;

[Authorize]
public class OrderController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<GetOrdersResponse>>> GetOrders(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetOrdersQuery(), cancellationToken);
        return response.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<PlaceOrderResponse>> PlaceOrder([FromBody] PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);
        return response.ToActionResult();
    }
}

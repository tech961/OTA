using Rs.Application.Features.Carts.CommandHandlers.AddCartItem;
using Rs.Application.Features.Carts.CommandHandlers.RemoveCartItem;
using Rs.Application.Features.Carts.QueryHandlers.GetCart;

namespace Rs.Api.Controllers;

[Authorize]
public class CartController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetCartResponse>> GetCart(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetCartQuery(), cancellationToken);
        return response.ToActionResult();
    }

    [HttpPost("items")]
    public async Task<ActionResult<AddCartItemResponse>> AddItem([FromBody] AddCartItemCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);
        return response.ToActionResult();
    }

    // [HttpDelete("items/{id:guid}")]
    // public async Task<ActionResult> RemoveItem(Guid id, CancellationToken cancellationToken)
    // {
    //     var command = new RemoveCartItemCommand(id);
    //     var response = await Mediator.Send(command, cancellationToken);
    //     return response.ToActionResult();
    // }
}

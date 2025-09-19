using Rs.Application.Features.Pets.CommandHandlers.AddPet;
using Rs.Application.Features.Pets.CommandHandlers.UpdatePet;
using Rs.Application.Features.Pets.CommandHandlers.DeletePet;
using Rs.Application.Features.Pets.QueryHandlers.GetPet;
using Rs.Application.Features.Pets.QueryHandlers.GetPets;

namespace Rs.Api.Controllers;

[Authorize]
public class PetController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<GetPetsResponse>>> GetPets(CancellationToken cancellationToken)
    {
        var query = new GetPetsQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return response.ToActionResult();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPetResponse>> GetPet(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetPetQuery(id);
        var response = await Mediator.Send(query, cancellationToken);
        return response.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<AddPetResponse>> AddPet(
        [FromForm] AddPetCommand command,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);
        return response.ToActionResult();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpdatePetResponse>> UpdatePet(Guid id, [FromForm] UpdatePetCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);
        return response.ToActionResult();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DeletePetResponse>> DeletePet(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePetCommand(id);
        var response = await Mediator.Send(command, cancellationToken);
        return response.ToActionResult();
    }
}

using Rs.Api.Contracts.ToDoItems.Requests;
using Rs.Api.Contracts.ToDoItems.Responses;
using Rs.Application.ToDos.Commands.CreateToDoItem;
using Rs.Application.ToDos.Commands.DeleteToDoItem;
using Rs.Application.ToDos.Commands.UpdateToDoItem;
using Rs.Application.ToDos.Queries.GetToDoItemById;
using Rs.Application.ToDos.Queries.GetToDoItems;

namespace Rs.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ToDoItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ToDoItemResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ToDoItemResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetToDoItemsQuery(), cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = _mapper.Map<IEnumerable<ToDoItemResponse>>(result.Value);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ToDoItemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ToDoItemResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetToDoItemByIdQuery(id), cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = _mapper.Map<ToDoItemResponse>(result.Value);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ToDoItemResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ToDoItemResponse>> Create(
        [FromBody] CreateToDoItemRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateToDoItemCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = _mapper.Map<ToDoItemResponse>(result.Value);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ToDoItemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ToDoItemResponse>> Update(
        Guid id,
        [FromBody] UpdateToDoItemRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateToDoItemCommand>(request) with { Id = id };

        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = _mapper.Map<ToDoItemResponse>(result.Value);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteToDoItemCommand(id), cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return NoContent();
    }

    private ActionResult HandleFailure(Result result)
    {
        var statusCode = result.Error.HttpCode.HasValue
            ? (int)result.Error.HttpCode.Value
            : StatusCodes.Status400BadRequest;

        return Problem(statusCode: statusCode, title: result.Error.Code, detail: result.Error.Message);
    }
}

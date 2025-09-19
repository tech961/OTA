namespace Rs.Api.Contracts.Base;

[ApiController]
[Produces("application/json")]
public class MainBaseController: ControllerBase
{
    private IMediator _mediatorInstance;
    private IMapper _mapperInstance;
    protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    protected IMapper Mapper => _mapperInstance ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
}
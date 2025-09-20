namespace Rs.Application.ToDos.Commands.UpdateToDoItem;

public class UpdateToDoItemCommandHandler : ICommandHandler<UpdateToDoItemCommand, ToDoItemDto>
{
    private readonly IToDoItemRepository _toDoItemRepository;
    private readonly IToDoItemDomainService _domainService;
    private readonly IMapper _mapper;

    public UpdateToDoItemCommandHandler(
        IToDoItemRepository toDoItemRepository,
        IToDoItemDomainService domainService,
        IMapper mapper)
    {
        _toDoItemRepository = toDoItemRepository;
        _domainService = domainService;
        _mapper = mapper;
    }

    public async Task<Result<ToDoItemDto>> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = await _toDoItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (toDoItem is null)
        {
            return Result.Failure<ToDoItemDto>(ToDoErrors.NotFound(request.Id));
        }

        var validationResult = _domainService.ValidateStatusTransition(toDoItem.Status, request.Status);

        if (validationResult.IsFailure)
        {
            return Result.Failure<ToDoItemDto>(validationResult.Error);
        }

        toDoItem.UpdateDetails(request.Title, request.Description);
        toDoItem.UpdateStatus(request.Status);

        _toDoItemRepository.Update(toDoItem);

        var dto = _mapper.Map<ToDoItemDto>(toDoItem);

        return Result.Success(dto);
    }
}

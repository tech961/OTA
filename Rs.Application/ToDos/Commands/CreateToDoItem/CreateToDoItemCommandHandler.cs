namespace Rs.Application.ToDos.Commands.CreateToDoItem;

public class CreateToDoItemCommandHandler : ICommandHandler<CreateToDoItemCommand, ToDoItemDto>
{
    private readonly IToDoItemRepository _toDoItemRepository;
    private readonly IMapper _mapper;

    public CreateToDoItemCommandHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
    {
        _toDoItemRepository = toDoItemRepository;
        _mapper = mapper;
    }

    public async Task<Result<ToDoItemDto>> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = ToDoItem.Create(request.Title, request.Description, request.Status);

        await _toDoItemRepository.AddAsync(toDoItem, cancellationToken);

        var dto = _mapper.Map<ToDoItemDto>(toDoItem);

        return Result.Success(dto);
    }
}

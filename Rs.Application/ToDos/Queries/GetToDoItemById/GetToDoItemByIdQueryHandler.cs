namespace Rs.Application.ToDos.Queries.GetToDoItemById;

public class GetToDoItemByIdQueryHandler : IQueryHandler<GetToDoItemByIdQuery, ToDoItemDto>
{
    private readonly IToDoItemRepository _toDoItemRepository;
    private readonly IMapper _mapper;

    public GetToDoItemByIdQueryHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
    {
        _toDoItemRepository = toDoItemRepository;
        _mapper = mapper;
    }

    public async Task<Result<ToDoItemDto>> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
    {
        var toDoItem = await _toDoItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (toDoItem is null)
        {
            return Result.Failure<ToDoItemDto>(ToDoErrors.NotFound(request.Id));
        }

        var dto = _mapper.Map<ToDoItemDto>(toDoItem);

        return Result.Success(dto);
    }
}

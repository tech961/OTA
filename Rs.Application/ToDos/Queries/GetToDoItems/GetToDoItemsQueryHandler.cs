namespace Rs.Application.ToDos.Queries.GetToDoItems;

public class GetToDoItemsQueryHandler : IQueryHandler<GetToDoItemsQuery, IReadOnlyCollection<ToDoItemDto>>
{
    private readonly IToDoItemRepository _toDoItemRepository;
    private readonly IMapper _mapper;

    public GetToDoItemsQueryHandler(IToDoItemRepository toDoItemRepository, IMapper mapper)
    {
        _toDoItemRepository = toDoItemRepository;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyCollection<ToDoItemDto>>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _toDoItemRepository.GetAllAsync(cancellationToken);

        var dto = _mapper.Map<List<ToDoItemDto>>(items);

        return Result.Success<IReadOnlyCollection<ToDoItemDto>>(dto);
    }
}

namespace Rs.Application.ToDos.Commands.DeleteToDoItem;

public class DeleteToDoItemCommandHandler : ICommandHandler<DeleteToDoItemCommand>
{
    private readonly IToDoItemRepository _toDoItemRepository;

    public DeleteToDoItemCommandHandler(IToDoItemRepository toDoItemRepository)
    {
        _toDoItemRepository = toDoItemRepository;
    }

    public async Task<Result> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = await _toDoItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (toDoItem is null)
        {
            return Result.Failure(ToDoErrors.NotFound(request.Id));
        }

        _toDoItemRepository.Remove(toDoItem);

        return Result.Success();
    }
}

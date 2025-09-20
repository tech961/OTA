namespace Rs.Domain.ToDos.Services;

public interface IToDoItemDomainService
{
    Result ValidateStatusTransition(ToDoStatus currentStatus, ToDoStatus newStatus);
}

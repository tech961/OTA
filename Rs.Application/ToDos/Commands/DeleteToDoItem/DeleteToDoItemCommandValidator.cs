namespace Rs.Application.ToDos.Commands.DeleteToDoItem;

public class DeleteToDoItemCommandValidator : AbstractValidator<DeleteToDoItemCommand>
{
    public DeleteToDoItemCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();
    }
}

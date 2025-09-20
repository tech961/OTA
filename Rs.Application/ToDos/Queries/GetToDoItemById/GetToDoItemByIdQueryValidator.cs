namespace Rs.Application.ToDos.Queries.GetToDoItemById;

public class GetToDoItemByIdQueryValidator : AbstractValidator<GetToDoItemByIdQuery>
{
    public GetToDoItemByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty();
    }
}

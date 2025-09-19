namespace Rs.Application.Features.Pets.QueryHandlers.GetPet;

public class GetPetQueryValidator : AbstractValidator<GetPetQuery>
{
    public GetPetQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}

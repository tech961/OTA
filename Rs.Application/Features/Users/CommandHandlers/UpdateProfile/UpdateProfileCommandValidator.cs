namespace Rs.Application.Features.Users.CommandHandlers.UpdateProfile;

public class UpdateProfileCommandValidator
    : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("نام باید حداقل ۳ کاراکتر باشد.")
            .MaximumLength(50).WithMessage("نام باید حداکثر ۵۰ کاراکتر باشد.");
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("نام خانوادگی باید حداقل ۳ کاراکتر باشد.")
            .MaximumLength(50).WithMessage("نام خانوادگی باید حداکثر ۵۰ کاراکتر باشد.");
    }
}
namespace Rs.Application.Features.Auths.CommandHandlers.SendVerificationCode;

public class SendVerificationCodeCommandValidator
    : AbstractValidator<SendVerificationCodeCommand>
{
    public SendVerificationCodeCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Must(ValidatorUtility.BeAValidPhoneNumberOrEmail)
            .WithMessage("فرمت شماره تماس درست نمی باشد.");
    }
}
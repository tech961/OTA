namespace Rs.Application.Features.Auths.CommandHandlers.OtpLogin;

public class OtpLoginCommandValidator
    : AbstractValidator<OtpLoginCommand>
{
    public OtpLoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
                .WithMessage("شماره تماس الزامی می باشد")
            .Must(ValidatorUtility.BeAValidPhoneNumberOrEmail)
                .WithMessage("فرمت شماره تماس درست نمی باشد");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("کد احراز هویت الزامی می باشد")
            .Length(5).WithMessage("کد احراز هویت باید دقیقا ۵ کاراکتر باشد");
    }
}
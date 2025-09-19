namespace Rs.Application.Features.Auths.CommandHandlers.SendVerificationCode;

public sealed record SendVerificationCodeCommand(string Username) : ICommand<bool>;

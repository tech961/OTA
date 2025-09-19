namespace Rs.Application.Features.Auths.CommandHandlers.OtpLogin;

public sealed record OtpLoginCommand(string Username, string Code) : ICommand<OtpLoginResponse>;

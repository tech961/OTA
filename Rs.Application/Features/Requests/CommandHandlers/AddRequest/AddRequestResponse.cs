namespace Rs.Application.Features.Requests.CommandHandlers.AddRequest;

public sealed class AddRequestResponse(bool isSuccess)
{
    public bool IsSuccess { get; set; } = isSuccess;
}
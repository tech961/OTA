namespace Rs.Application.Features.Requests.CommandHandlers.AddRequest;

public sealed record AddRequestCommand : ICommand<AddRequestResponse>
{
    public RequestType RequestType { get; set; }

    public EstateType EstateType { get; set; }

    public string EstateOptions { get; set; }

    public string? Location { get; set; }

    public int MinArea { get; set; }

    public int MaxArea { get; set; }

    public byte RoomNumber { get; set; }

    public byte WcNumber { get; set; }

    public byte BathRoomNumber { get; set; }

    public long MinPrice { get; set; }

    public long MaxPrice { get; set; }
}
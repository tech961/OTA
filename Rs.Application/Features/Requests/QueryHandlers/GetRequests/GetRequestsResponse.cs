using Rs.Domain.Aggregates.Requests;

namespace Rs.Application.Features.Requests.QueryHandlers.GetRequests;

[AutoMap(typeof(Request))]
public sealed class GetRequestsResponse
{
    public RequestType RequestType { get; set; }

    public EstateType EstateType { get; set; }

    public string? EstateOptions { get; set; }

    public RequestStatus Status { get; set; }

    public string? Location { get; set; }

    public int MinArea { get; set; }

    public int MaxArea { get; set; }

    public byte RoomNumber { get; set; }

    public byte WcNumber { get; set; }

    public byte BathRoomNumber { get; set; }

    public long MinPrice { get; set; }

    public long MaxPrice { get; set; }

    // TODO adding enum helper
    public string RequestName { get; set; } = "اجاره خانه";
}
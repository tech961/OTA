using Microsoft.EntityFrameworkCore.Infrastructure;
using Rs.Domain.Aggregates.RealEstates;

namespace Rs.Domain.Aggregates.Requests;

public class Request : BaseAuditableEntity
{
    private readonly List<RealEstateTrackingRequest> _realEstateTrackingRequests = [];
    public RequestType RequestType { get; private set; }

    public EstateType EstateType { get; private set; }

    public string EstateOptions { get; private set; }

    public RequestStatus? Status { get; private set; }

    public string? Location { get; private set; }

    public int MinArea { get; private set; }

    public int MaxArea { get; private set; }

    public byte RoomNumber { get; private set; }

    public byte WcNumber { get; private set; }

    public byte BathRoomNumber { get; private set; }

    public long MinPrice { get; private set; }

    public long MaxPrice { get; private set; }

    public IReadOnlyCollection<RealEstateTrackingRequest> RealEstateTrackingRequests => _realEstateTrackingRequests;

    public static Request AddRequest(RequestType requestType,
        EstateType estateType,
        string estateOptions,
        string? location,
        int minArea,
        int maxArea,
        byte roomNumber,
        byte wcNumber,
        byte bathRoomNumber,
        long minPrice,
        long maxPrice)
    {
        var request = new Request()
        {
            RequestType = requestType,
            EstateType = estateType,
            EstateOptions = estateOptions,
            Location = location,
            MinArea = minArea,
            MaxArea = maxArea,
            RoomNumber = roomNumber,
            WcNumber = wcNumber,
            BathRoomNumber = bathRoomNumber,
            MinPrice = minPrice,
            MaxPrice = maxPrice
        };

        return request;
    }
}
using Rs.Domain.Aggregates.Requests;

namespace Rs.Application.Features.Requests.CommandHandlers.AddRequest;

public class AddRequestCommandHandler(IDataContext context)
    : ICommandHandler<AddRequestCommand, AddRequestResponse>
{
    public async Task<Result<AddRequestResponse>> Handle(AddRequestCommand request,
        CancellationToken cancellationToken)
    {
        var requestModel = Request.AddRequest(request.RequestType,
            request.EstateType,
            request.EstateOptions,
            request.Location,
            request.MinArea,
            request.MaxArea,
            request.RoomNumber,
            request.WcNumber,
            request.BathRoomNumber,
            request.MinPrice,
            request.MaxPrice);

        await context.Requests.AddAsync(requestModel, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new AddRequestResponse(true);
    }
}
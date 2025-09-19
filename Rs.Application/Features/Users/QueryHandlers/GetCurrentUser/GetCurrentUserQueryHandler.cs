namespace Rs.Application.Features.Users.QueryHandlers.GetCurrentUser;

public class GetCurrentUserQueryHandler(IDataContext context,
    IMapper mapper,
    IUser user) 
    : IQueryHandler<GetCurrentUserQuery, GetCurrentUserResponse>
{
    public async Task<Result<GetCurrentUserResponse>> Handle(GetCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        var userModel = await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(us => user.Id != null && us.Id == user.Id.Value, cancellationToken);

        if (userModel == null)
        {
            return Result.Failure<GetCurrentUserResponse>(UserErrors.UserNotFound);
        }

        var queryResponse = mapper.Map<GetCurrentUserResponse>(userModel);
        return queryResponse;
    }
}
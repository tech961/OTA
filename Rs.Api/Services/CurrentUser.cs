using Rs.Domain.Common.Interfaces;

namespace Rs.Api.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public Guid? Id
    {
        get
        {
            var userIdString = httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (Guid.TryParse(userIdString, out var userIdGuid))
            {
                return userIdGuid;
            }
            
            return null;
        }
    }
}

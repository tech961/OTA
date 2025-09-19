namespace Rs.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result<bool>> IsInRoleAsync(string userId, string role);

    Task<Result<bool>> AuthorizeAsync(string userId, string policyName);

    Result<string> GetJwtToken(User user);
}
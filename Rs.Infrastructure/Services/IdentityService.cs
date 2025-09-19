using Rs.Domain.Aggregates.Auths;
using Rs.Domain.Options;
using Rs.Domain.Shared;

namespace Rs.Infrastructure.Services;

public class IdentityService(
    UserManager<User> userManager,
    IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService,
    IOptions<JwtSettings> jwtSettings)
    : IIdentityService
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new();
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public async Task<Result<bool>> IsInRoleAsync(string userId, string role)
    {
        var user = await userManager.FindByIdAsync(userId);

        return user != null && await userManager.IsInRoleAsync(user, role);
    }

    public async Task<Result<bool>> AuthorizeAsync(string userId, string policyName)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        var principal = await userClaimsPrincipalFactory.CreateAsync(user);

        var result = await authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public Result<string> GetJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        };

        var claimsIdentity = new ClaimsIdentity(claims);
        var token = CreateSecurityToken(claimsIdentity);
        return WriteToken(token);
    }

    private SecurityTokenDescriptor GetTokenDescriptor(ClaimsIdentity identity) =>
        new()
        {
            Subject = identity,
            Expires = DateTime.Now.AddDays(360),
            Audience = _jwtSettings.Audiences[0],
            Issuer = _jwtSettings.Issuer,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SigningKey)),
                SecurityAlgorithms.HmacSha256Signature)
        };

    private SecurityToken CreateSecurityToken(ClaimsIdentity identity)
    {
        var tokenDescriptor = GetTokenDescriptor(identity);

        return _tokenHandler.CreateToken(tokenDescriptor);
    }

    private string WriteToken(SecurityToken token) =>
        _tokenHandler.WriteToken(token);
}
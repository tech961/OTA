namespace Rs.Infrastructure.Services;

public class TokenProviderService : ITokenProviderService
{
    public string GenerateToken()
    {
        var random = new Random();
        
        return random.Next(10000, 99999).ToString();
    }
}
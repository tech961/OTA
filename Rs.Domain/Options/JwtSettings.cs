namespace Rs.Domain.Options;

public class JwtSettings
{
    public string SigningKey { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string[] Audiences { get; init; } = null!;
}
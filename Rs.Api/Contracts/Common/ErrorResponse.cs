namespace Rs.Api.Contracts.Common;

public class ErrorResponse
{
    public int Status { get; set; }
    public string? StatusPhrase { get; set; }
    public List<ErrorItem> Errors { get; set; }
    public DateTime Timestamp { get; set; }
}

public record ErrorItem(string Code, string Message);

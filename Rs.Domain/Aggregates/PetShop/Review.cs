namespace Rs.Domain.Aggregates.PetShop;

public class Review : BaseAuditableEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Guid UserId { get; set; }
    public int Rating { get; set; }
    public string Title { get; set; } = null!;
    public string? Comment { get; set; }
}

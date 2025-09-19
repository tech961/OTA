using Rs.Domain.Shared.Enums.Pet;
using Rs.Domain.Shared.Enums.PetShop;

namespace Rs.Domain.Aggregates.PetShop;

public class ProductSuitability : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Species Species { get; set; }
    public string? Breed { get; set; }
    public AgeGroup AgeGroup { get; set; }
    public Size Size { get; set; }
    public HealthCondition HealthCondition { get; set; }
}

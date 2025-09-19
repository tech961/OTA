using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class ProductSuitabilityConfiguration : IEntityTypeConfiguration<ProductSuitability>
{
    public void Configure(EntityTypeBuilder<ProductSuitability> builder)
    {
        builder.ToTable("ProductSuitabilities", SchemaConfig.PetShop);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Species).HasConversion<string>().IsRequired();
        builder.Property(s => s.AgeGroup).HasConversion<string>().IsRequired();
        builder.Property(s => s.Size).HasConversion<string>().IsRequired();
        builder.Property(s => s.HealthCondition).HasConversion<string>().IsRequired();
        builder.Property(s => s.Breed).HasMaxLength(128);

        builder.HasOne(s => s.Product)
            .WithMany(p => p.Suitabilities)
            .HasForeignKey(s => s.ProductId);

        builder.HasIndex(s => new
        {
            s.ProductId,
            s.Species,
            s.Breed,
            s.AgeGroup,
            s.Size,
            s.HealthCondition
        }).IsUnique();
    }
}

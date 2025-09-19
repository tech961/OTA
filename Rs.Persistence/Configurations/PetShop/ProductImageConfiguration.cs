using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages", SchemaConfig.PetShop);
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ImageUrl).IsRequired();

        builder.HasOne(i => i.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(i => i.ProductId);

        builder.HasIndex(i => new { i.ProductId, i.IsPrimary })
            .IsUnique()
            .HasFilter("[IsPrimary] = 1");
    }
}

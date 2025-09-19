using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.ToTable("Wishlists", SchemaConfig.PetShop);
        builder.HasKey(w => w.Id);

        builder.HasOne(w => w.Product)
            .WithMany()
            .HasForeignKey(w => w.ProductId);

        builder.HasIndex(w => new { w.UserId, w.ProductId }).IsUnique();
    }
}

using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems", SchemaConfig.PetShop);
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.UnitPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(ci => ci.CartId);

        builder.HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId);

        builder.HasIndex(ci => new { ci.CartId, ci.ProductId }).IsUnique();
    }
}

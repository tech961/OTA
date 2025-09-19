using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts", SchemaConfig.PetShop);
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Status).HasConversion<string>().IsRequired();
    }
}

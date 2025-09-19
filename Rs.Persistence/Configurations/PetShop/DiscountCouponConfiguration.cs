using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class DiscountCouponConfiguration : IEntityTypeConfiguration<DiscountCoupon>
{
    public void Configure(EntityTypeBuilder<DiscountCoupon> builder)
    {
        builder.ToTable("DiscountCoupons", SchemaConfig.PetShop);
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion(v => v.ToUpperInvariant(), v => v);

        builder.Property(c => c.Type).HasConversion<string>().IsRequired();
        builder.Property(c => c.Value).HasColumnType("decimal(18,2)");
        builder.Property(c => c.MinOrderAmount).HasColumnType("decimal(18,2)");

        builder.HasIndex(c => c.Code).IsUnique();
    }
}

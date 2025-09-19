using Rs.Domain.Aggregates.PetShop;
using Rs.Domain.Aggregates.PetShop.ValueObjects;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", SchemaConfig.PetShop);
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Status).HasConversion<string>().IsRequired();
        builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.DiscountAmount).HasColumnType("decimal(18,2)");
        builder.Property(o => o.OrderNumber).IsRequired().HasMaxLength(64);

        builder.OwnsOne(o => o.ShippingAddress, a =>
        {
            a.Property(p => p.FirstName).HasMaxLength(100);
            a.Property(p => p.LastName).HasMaxLength(100);
            a.Property(p => p.Phone).HasMaxLength(50);
            a.Property(p => p.Country).HasMaxLength(100);
            a.Property(p => p.City).HasMaxLength(100);
            a.Property(p => p.Line1).HasMaxLength(200);
            a.Property(p => p.Line2).HasMaxLength(200);
            a.Property(p => p.PostalCode).HasMaxLength(20);
        });

        builder.OwnsOne(o => o.BillingAddress, a =>
        {
            a.Property(p => p.FirstName).HasMaxLength(100);
            a.Property(p => p.LastName).HasMaxLength(100);
            a.Property(p => p.Phone).HasMaxLength(50);
            a.Property(p => p.Country).HasMaxLength(100);
            a.Property(p => p.City).HasMaxLength(100);
            a.Property(p => p.Line1).HasMaxLength(200);
            a.Property(p => p.Line2).HasMaxLength(200);
            a.Property(p => p.PostalCode).HasMaxLength(20);
        });

        builder.HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId);

        builder.HasOne(o => o.Payment)
            .WithOne(p => p.Order)
            .HasForeignKey<Payment>(p => p.OrderId);

        builder.HasOne(o => o.Shipment)
            .WithOne(s => s.Order)
            .HasForeignKey<Shipment>(s => s.OrderId);
    }
}

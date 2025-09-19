using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems", SchemaConfig.PetShop);
        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
        // builder.Property(oi => oi.SubTotal)
        //     .HasColumnType("decimal(18,2)")
        //     .HasComputedColumnSql("[Quantity] * [UnitPrice]");

        builder.HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);
    }
}

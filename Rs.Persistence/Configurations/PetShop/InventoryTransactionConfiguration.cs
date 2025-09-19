using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
    {
        builder.ToTable("InventoryTransactions", SchemaConfig.PetShop);
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Reason).HasConversion<string>().IsRequired();
        builder.Property(t => t.Note).HasMaxLength(500);

        builder.HasOne(t => t.Product)
            .WithMany(p => p.InventoryTransactions)
            .HasForeignKey(t => t.ProductId);
    }
}

using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("Shipments", SchemaConfig.PetShop);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Status).HasConversion<string>().IsRequired();
        builder.Property(s => s.Carrier).IsRequired().HasMaxLength(100);
    }
}

using Rs.Domain.Aggregates.PetShop;
using Rs.Persistence.Common;

namespace Rs.Persistence.Configurations.PetShop;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments", SchemaConfig.PetShop);
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Method).HasConversion<string>().IsRequired();
        builder.Property(p => p.Status).HasConversion<string>().IsRequired();
        builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
    }
}

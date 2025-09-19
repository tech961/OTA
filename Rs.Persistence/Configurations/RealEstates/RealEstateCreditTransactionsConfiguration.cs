using Rs.Domain.Aggregates.RealEstates;
using Rs.Domain.Shared.Enums;

namespace Rs.Persistence.Configurations.RealEstates;

public class RealEstateCreditTransactionsConfiguration
    : IEntityTypeConfiguration<RealEstateCreditTransaction>
{
    public void Configure(EntityTypeBuilder<RealEstateCreditTransaction> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.PaymentStatus)
            .HasDefaultValue(PaymentStatusEnum.PrePayment);

        builder.HasOne(c => c.RealEstate)
            .WithMany()
            .HasForeignKey(c => c.RealEstateId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("RealEstateCreditTransactions", SchemaConfig.RealEstate);
    }
}
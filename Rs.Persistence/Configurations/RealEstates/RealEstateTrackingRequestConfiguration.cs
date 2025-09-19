using Rs.Domain.Aggregates.RealEstates;
using Rs.Domain.Shared.Enums;

namespace Rs.Persistence.Configurations.RealEstates;

public class RealEstateTrackingRequestConfiguration
    : IEntityTypeConfiguration<RealEstateTrackingRequest>
{
    public void Configure(EntityTypeBuilder<RealEstateTrackingRequest> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.ResponseDescription)
            .HasMaxLength(1000);

        builder.HasOne(c => c.Request)
            .WithMany(c => c.RealEstateTrackingRequests)
            .HasForeignKey(c => c.RequestId);

        builder.HasOne(c => c.RealEstate)
            .WithMany(c => c.RealEstateTrackingRequests)
            .HasForeignKey(c => c.RealEstateId);

        builder.HasOne(c => c.TrackingBy)
            .WithMany()
            .HasForeignKey(c => c.TrackingById);

        builder.Property(c => c.Response)
            .HasDefaultValue(RealEstateResponseEnum.Pending);

        builder.ToTable("RealEstateTrackingRequests", SchemaConfig.RealEstate);
    }
}
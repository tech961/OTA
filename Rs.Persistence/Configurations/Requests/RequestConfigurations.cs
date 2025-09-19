using Rs.Domain.Aggregates.Requests;
using Rs.Domain.Shared.Enums.Requests;

namespace Rs.Persistence.Configurations.Requests;

public class RequestConfigurations : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Status)
            .HasDefaultValue(RequestStatus.Pending);
        
        builder.ToTable("Requests", SchemaConfig.Request);
    }
}
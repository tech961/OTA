using Rs.Domain.Aggregates.Pets;

namespace Rs.Persistence.Configurations.Pets;

public class ActivityRecordConfiguration : IEntityTypeConfiguration<ActivityRecord>
{
    public void Configure(EntityTypeBuilder<ActivityRecord> builder)
    {
        builder.HasKey(ar => ar.Id);

        builder.HasOne(ar => ar.Pet)
            .WithMany(p => p.Activities)
            .HasForeignKey(ar => ar.PetId);

        builder.Property(ar => ar.Notes)
            .HasMaxLength(500);

        builder.ToTable("ActivityRecords", SchemaConfig.Pet);
    }
}
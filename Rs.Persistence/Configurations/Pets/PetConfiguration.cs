using Rs.Domain.Aggregates.Pets;

namespace Rs.Persistence.Configurations.Pets;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Owner)
            .WithMany()
            .HasForeignKey(p => p.OwnerId);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PhotoUrl)
            .HasMaxLength(500);

        builder.Property(p => p.Species)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Breed)
            .HasMaxLength(100);

        builder.Property(p => p.Gender)
            .HasMaxLength(10);

        builder.Property(p => p.HealthStatus)
            .HasMaxLength(100);

        builder.Property(p => p.VaccinationStatus)
            .HasMaxLength(100);

        builder.Property(p => p.Country)
            .HasMaxLength(100);

        builder.Property(p => p.City)
            .HasMaxLength(100);

        builder.ToTable("Pets", SchemaConfig.Pet);
    }
}
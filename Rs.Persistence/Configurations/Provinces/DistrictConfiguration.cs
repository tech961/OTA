using Rs.Domain.Aggregates.Provinces;

namespace Rs.Persistence.Configurations.Provinces;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);

        builder.HasOne<City>(c => c.City)
            .WithMany(c => c.Districts)
            .HasForeignKey(c => c.CityId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Districts", SchemaConfig.Province);
    }
}
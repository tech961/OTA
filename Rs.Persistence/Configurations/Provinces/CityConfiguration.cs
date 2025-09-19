using Rs.Domain.Aggregates.Provinces;

namespace Rs.Persistence.Configurations.Provinces;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);
        
        builder.ToTable("Cities", SchemaConfig.Province);
    }
}
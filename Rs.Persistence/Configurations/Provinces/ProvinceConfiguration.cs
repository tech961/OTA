using Rs.Domain.Aggregates.Provinces;

namespace Rs.Persistence.Configurations.Provinces;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);
        
        builder.ToTable("Provinces", SchemaConfig.Province);
    }
}
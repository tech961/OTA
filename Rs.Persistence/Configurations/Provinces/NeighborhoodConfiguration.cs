using Rs.Domain.Aggregates.Provinces;

namespace Rs.Persistence.Configurations.Provinces;

public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
{
    public void Configure(EntityTypeBuilder<Neighborhood> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);

        builder.HasOne<District>(c => c.District)
            .WithMany(c => c.Neighborhoods)
            .HasForeignKey(c => c.DistrictId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Neighborhoods", SchemaConfig.Province);
    }
}
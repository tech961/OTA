using Rs.Domain.Aggregates.Provinces;
using Rs.Domain.Aggregates.RealEstates;

namespace Rs.Persistence.Configurations.RealEstates;

public class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
{
    public void Configure(EntityTypeBuilder<RealEstate> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.Credit)
            .HasDefaultValue(0);
        
        builder.Property(c => c.Loaction)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne(c => c.Neighborhood)
            .WithMany()
            .HasForeignKey(c => c.NeighborhoodId);

        builder.HasOne(c => c.Manager)
            .WithMany()
            .HasForeignKey(c => c.ManagerId);

        builder.ToTable("RealEstates", SchemaConfig.RealEstate);
    }
}
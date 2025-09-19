using Rs.Domain.Aggregates.RealEstates;

namespace Rs.Persistence.Configurations.RealEstates;

public class RealEstatePersonConfiguration : IEntityTypeConfiguration<RealEstatePerson>
{
    public void Configure(EntityTypeBuilder<RealEstatePerson> builder)
    {
        builder.HasKey(c => new {c.RealEstateId, c.UserId} );

        builder.HasOne(rep => rep.RealEstate)
            .WithMany(re => re.RealEstatePersons)
            .HasForeignKey(rep => rep.RealEstateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rep => rep.Users)
            .WithMany()
            .HasForeignKey(rep => rep.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("RealEstatePersons", SchemaConfig.RealEstate);
    }
}
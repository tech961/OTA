using Rs.Domain.Aggregates.Auths;

namespace Rs.Persistence.Configurations.Auths;

public class UserVerificationCodeConfiguration: IEntityTypeConfiguration<UserVerificationCode>
{
    public void Configure(EntityTypeBuilder<UserVerificationCode> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Code)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(c => c.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.ToTable("UserVerificationCodes", SchemaConfig.Auth);
    }
}
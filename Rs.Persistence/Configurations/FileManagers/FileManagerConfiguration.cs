using Rs.Domain.Aggregates.Files;

namespace Rs.Persistence.Configurations.FileManagers;

public class FileManagerConfiguration : IEntityTypeConfiguration<FileManager>
{
    public void Configure(EntityTypeBuilder<FileManager> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.ContentType)
            .IsRequired()
            .HasMaxLength(5);
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(c => c.PhysicalPath)
            .IsRequired()
            .HasMaxLength(500);

        builder.ToTable("FileManagers", SchemaConfig.File);
    }
}

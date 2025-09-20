using Rs.Domain.ToDos;

namespace Rs.Persistence.DbPersistence.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable("ToDoItems");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(item => item.Description)
            .HasMaxLength(1000);

        builder.Property(item => item.Status)
            .IsRequired()
            .HasConversion(
                status => status.ToString(),
                value => Enum.Parse<ToDoStatus>(value))
            .HasMaxLength(20);
    }
}

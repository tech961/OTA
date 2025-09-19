using Rs.Domain.Aggregates.Blogs;

namespace Rs.Persistence.Configurations.Blogs;

public class BlogConfiguration: IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.ToTable("Blogs", SchemaConfig.Blog);
    }
}
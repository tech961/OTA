namespace Rs.Domain.Aggregates.Blogs;

public class Blog : BaseAuditableEntity
{
    protected Blog()
    {
    }

    private Blog(string title,
        string description)
    {
        Title = title;
        Description = description;
        Created = DateTime.UtcNow;
        Published = false;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public bool Published { get; private set; }

    public static Blog AddBlog(string title, string description)
    {
        var blog = new Blog(title,
            description);

        return blog;
    }
}
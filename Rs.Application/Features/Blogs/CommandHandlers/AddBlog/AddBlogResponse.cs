using Rs.Domain.Aggregates.Blogs;

namespace Rs.Application.Features.Blogs.CommandHandlers.AddBlog;

[AutoMap(typeof(Blog))]
public sealed class AddBlogResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool Published { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }
}
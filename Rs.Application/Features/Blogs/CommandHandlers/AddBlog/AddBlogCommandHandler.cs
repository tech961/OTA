using Rs.Domain.Aggregates.Blogs;
using Rs.Domain.Events.Blogs;

namespace Rs.Application.Features.Blogs.CommandHandlers.AddBlog;

public class AddBlogCommandHandler(
    IDataContext context,
    IMapper mapper,
    ILogger<AddBlogCommandHandler> logger) 
    : ICommandHandler<AddBlogCommand, AddBlogResponse>
{
    public async Task<Result<AddBlogResponse>> Handle(AddBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = Blog.AddBlog(request.Title,
            request.Description);

        await context.Blogs.AddAsync(blog, cancellationToken);
        
        blog.AddDomainEvent(new AddBlogEvent(blog.Id));
        await context.SaveChangesAsync(cancellationToken);
        var response = mapper.Map<AddBlogResponse>(blog);

        return response;
    }
}
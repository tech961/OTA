
namespace Rs.Application.Features.Blogs.CommandHandlers.AddBlog;

public sealed record AddBlogCommand(string Title,string Description ) : ICommand<AddBlogResponse>;
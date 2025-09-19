using Rs.Application.Features.Blogs.CommandHandlers.AddBlog;

namespace Rs.Api.Controllers;

[Authorize]
public class BlogController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<AddBlogResponse>> AddBlog(
        [FromBody] AddBlogCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }
}
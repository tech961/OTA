using Rs.Application.Features.Users.CommandHandlers.UpdateProfile;
using Rs.Application.Features.Users.CommandHandlers.UploadProfilePic;
using Rs.Application.Features.Users.QueryHandlers.GetCurrentUser;

namespace Rs.Api.Controllers;

[Authorize]
public class UserController(IWebHostEnvironment webHostEnvironment) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetCurrentUserResponse>> GetCurrentUser(CancellationToken cancellationToken)
    {
        var query = new GetCurrentUserQuery();
        var response = await Mediator.Send(query, cancellationToken);

        return response.ToActionResult();
    }
    
    [HttpPatch("update-profile")]
    public async Task<ActionResult<UpdateProfileResponse>> UpdateProfile(
        [FromBody] UpdateProfileCommand command,
        CancellationToken cancellationToken)
    {
        var response =await Mediator.Send(command, cancellationToken);

        return response.ToActionResult();
    }

    [HttpPatch("upload-profile-pic")]
    public async Task<ActionResult<UploadProfilePicResponse>> UploadProfilePic(
        [FromForm] UploadProfilePicCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(command, cancellationToken);

        return response.ToActionResult();
    }
}
using Rs.Application.Features.Auths.CommandHandlers.OtpLogin;
using Rs.Application.Features.Auths.CommandHandlers.SendVerificationCode;

namespace Rs.Api.Controllers;

public class AuthController: BaseController
{
    [HttpPost]
    [Route("send-verification-code")]
    public async Task<ActionResult<bool>> SendVerificationCode([FromBody] SendVerificationCodeCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }
    
    [HttpPost]
    [Route("otp-login")]
    public async Task<ActionResult<OtpLoginResponse>> OtpLogin([FromBody] OtpLoginCommand request,
        CancellationToken cancellationToken)
    {   
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }
}
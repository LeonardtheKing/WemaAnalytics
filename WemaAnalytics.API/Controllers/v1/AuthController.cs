using MediatR;
using Uplift.Application.Constants;
using WemaAnalytics.Application.Login;
using WemaAnalytics.Application.Login.Command;

namespace WemaAnalytics.API.Controllers.v1
{
    public class AuthController(ISender sender) : BaseControllerV1
    {
    
        [HttpPost("login")]
        [ProducesResponseType<BaseResponse<LoginResponse>>(200)]
        [SwaggerResponse(400, "Bad Request", typeof(BaseResponse<LoginResponse>))]
        [SwaggerResponse(401, "Unauthorized", typeof(BaseResponse<LoginResponse>))]
        [SwaggerResponse(500, "Internal Server Error", typeof(BaseResponse<LoginResponse>))]
        [SwaggerOperation(Summary = "Login", Description = "Login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellation)
        {
            BaseResponse<LoginResponse> response = await sender.Send(command, cancellation);
            return HandleResponse(response);
        }

    }
}

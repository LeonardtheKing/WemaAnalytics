﻿using Uplift.Application.Constants;

namespace WemaAnalytics.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public abstract class BaseControllerV1 : ControllerBase
    {
        protected string LoggedInUserEmail => User.FindFirstValue(ClaimTypes.Email) ?? throw new FormatException("Active user email not encrypted in token");
        protected string LoggedInUserId => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new FormatException("Active user id not encrypted in token");

        protected IActionResult HandleResponse<T>(BaseResponse<T> response)
        {
            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Response is null." });
            }

            return response.StatusCode switch
            {
                ResponseCodes.Ok => Ok(response),
                ResponseCodes.NotFound => NotFound(response),
                ResponseCodes.BadRequest => BadRequest(response),
                ResponseCodes.Unauthorized => Unauthorized(response),
                ResponseCodes.InternalServer => StatusCode(StatusCodes.Status500InternalServerError, response),
                _ => StatusCode(StatusCodes.Status500InternalServerError, response)
            };
        }
    }
}

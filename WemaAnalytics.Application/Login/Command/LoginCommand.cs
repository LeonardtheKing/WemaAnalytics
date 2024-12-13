using Uplift.Application.Constants;

namespace WemaAnalytics.Application.Login.Command;

public record LoginCommand : CurrentUserProps, IRequest<BaseResponse<LoginResponse>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

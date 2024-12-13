namespace WemaAnalytics.Application.Services
{
    public interface IAccessorService
    {
        string GetClientDeviceName();
        string GetClientIpAddress();
    }
    public class AccessorService(IHttpContextAccessor httpContextAccessor) : IAccessorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string GetClientDeviceName()
        {
            HttpContext? context = _httpContextAccessor.HttpContext;
            if (context == null)
                return "Unknown";

            return context.Request.Headers.UserAgent.ToString() ?? "Unknown Device";
        }

        public string GetClientIpAddress()
        {
            HttpContext? context = _httpContextAccessor.HttpContext;
            if (context == null)
                return "Unknown";

            return context.Connection?.RemoteIpAddress?.ToString() ?? "Unknown IP";
        }
    }
}

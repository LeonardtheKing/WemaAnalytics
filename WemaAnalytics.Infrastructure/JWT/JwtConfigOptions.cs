namespace WemaAnalytics.Infrastructure.JWT;

public class JwtConfigOptions
{
    public string ValidIssuer { get; set; } = string.Empty;
    public string ValidAudience { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public int TokenExpiryInMinutes { get; set; }
}

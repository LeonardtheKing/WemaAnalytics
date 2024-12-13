using WemaAnalytics.Infrastructure.JWT;

namespace WemaAnalytics.Application.Services;

public interface IJwtService
{
    string GenerateJWT(List<Claim> claims);
    Task<string> GenerateRefreshToken();
    void RevokeToken(string token);
    bool IsTokenRevoked(string token);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Guid GetUserIdFromToken(string token);
    string GetUserIdFromToken();
}
public class JwtService(IOptions<JwtConfigOptions> options,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor) : IJwtService
{
    private static readonly Dictionary<string, DateTime> RevokedTokens = new Dictionary<string, DateTime>();
    private readonly JwtConfigOptions _options = options.Value;

    public string GenerateJWT(List<Claim> claims)
    {
        var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

        // Add jti claim to uniquely identify the token
        var jti = Guid.NewGuid().ToString();
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, jti));

        var tokenObject = new JwtSecurityToken(
            issuer: _options.ValidIssuer,
            audience: _options.ValidAudience,
            expires: DateTime.Now.AddMinutes(30),
            claims: claims,
            signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
        );

        string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

        return token;
    }

    public async Task<string> GenerateRefreshToken()
    {
        await Task.Delay(0);
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public void RevokeToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        if (jwtToken != null)
        {
            string jti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value!;
            if (jti != null)
            {
                RevokedTokens[jti] = jwtToken.ValidTo;
            }
        }
    }

    public bool IsTokenRevoked(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        if (jwtToken != null)
        {
            string jti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            if (jti != null)
            {
                return RevokedTokens.ContainsKey(jti);
            }
        }
        return false;
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken securityToken);

        var jwtToken = securityToken as JwtSecurityToken;
        if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    public Guid GetUserIdFromToken(string token)
    {
        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

        // Look for the "nameidentifier" claim which holds the UserId
        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

        return userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;
    }

    public string GetUserIdFromToken()
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user == null)
        {
            throw new Exception("User context is null");
        }

        // Get the 'sub' claim, which is typically the userId in a JWT token
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)
                           ?? user.FindFirst("sub");  // JWT 'sub' claim

        if (userIdClaim == null)
        {
            throw new Exception("UserId claim not found in token");
        }

        return userIdClaim.Value; // This is the userId
    }

}
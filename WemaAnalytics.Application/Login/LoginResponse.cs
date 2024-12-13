namespace WemaAnalytics.Application.Login;

public record LoginResponse(string Name, string Email, string JwtToken, string RefreshToken, string UserRole,string StaffId);



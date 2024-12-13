namespace WemaAnalytics.Application.Models.Auth
{
    public record LoginModel
    {
        public required string Email { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime Expiry { get; set; }
    }
}

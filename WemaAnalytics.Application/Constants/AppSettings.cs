namespace WemaAnalytics.Application.Constants
{
    public record AppSettings
    {
        public required MailSettings MailSettings { get; set; }
        public required string FrontendBaseUrl { get; set; }
    }

    public record MailSettings
    {
        public string? EmailUrl { get; set; }
        public required string From { get; set; }
        public bool ActivateMailSending { get; set; }
    }
}

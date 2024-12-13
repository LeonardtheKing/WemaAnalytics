namespace WemaAnalytics.Application.Models.Common
{
    public record MailModel
    {
        public required string To { get; set; }
        public string From { get; set; } = string.Empty;
        public required string Subject { get; set; }
        public required string Body { get; set; }
        public List<IFormFile> Attachments { get; set; } = [];
    }
}

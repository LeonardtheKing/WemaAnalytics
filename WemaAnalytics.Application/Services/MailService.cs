namespace WemaAnalytics.Application.Services
{
    public interface IMailService
    {
        Task<string> SendEmail(MailModel mail);
        string LoadTemplate(string htmlFileName);
    }
    public class MailService(IOptions<AppSettings> options, UtilityHelper utilityHelper, IHttpClientFactory httpClientFactory, IHostEnvironment hostEnvironment) : IMailService
    {
        private readonly MailSettings _mailSettings = options.Value.MailSettings;
        private readonly UtilityHelper _utilityHelper = utilityHelper;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

        public async Task<string> SendEmail(MailModel mail)
        {
            mail.From = _mailSettings.From;
            string nameUrl = $"{_mailSettings.EmailUrl}SendEmail";
            HttpClient client = _httpClientFactory.CreateClient("Mail");

            string requestObject = JsonConvert.SerializeObject(mail);
            HttpRequestMessage req = new(HttpMethod.Post, nameUrl)
            {
                Content = new StringContent(
                    requestObject,
                    Encoding.UTF8,
                    "application/json")
            };

            HttpResponseMessage response = await client.SendAsync(req);
            string output = await response.Content.ReadAsStringAsync();
            string authResponse = _utilityHelper.Deserializer<string>(output) ?? string.Empty;
            return authResponse;
        }

        public string LoadTemplate(string htmlFileName)
        {
            string templatePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "EmailTemplates", $"{htmlFileName}.html");
            return File.ReadAllText(templatePath);
        }
    }
}

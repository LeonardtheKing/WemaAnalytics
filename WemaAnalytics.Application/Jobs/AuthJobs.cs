namespace WemaAnalytics.Application.Jobs
{
    public class AuthJobs(IServiceScopeFactory serviceScopeFactory)
    {
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

        public async Task SendPasswordResetEmail(string emailAddress, string firstName, string resetUrl)
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            IMailService _emailService = scope.ServiceProvider.GetRequiredService<IMailService>();

            StringBuilder sb = new(_emailService.LoadTemplate("password-reset"));

            sb.Replace("{{FirstName}}", firstName);
            sb.Replace("{{resetLink}}", resetUrl);
            sb.Replace("{{Year}}", DateTime.UtcNow.Year.ToString());

            MailModel msg = new()
            {
                To = emailAddress,
                Subject = $"Password Reset Request",
                Body = sb.ToString()
            };

            await _emailService.SendEmail(msg);
        }
    }
}

namespace InsuranceSolution.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public ILogger<EmailService> _logger { get; }
        private readonly IHttpClientFactory _httpClientFactory;

        public EmailService(ILogger<EmailService> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Application.Models.Email.Email email)
        {
            bool result = false;

            try
            {
                var httpClient = _httpClientFactory.CreateClient("MailerSendAPI");
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("email", email);
                response.EnsureSuccessStatusCode();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Email sending failed {ex.Message}");
            }
            return result;
        }
    }
}

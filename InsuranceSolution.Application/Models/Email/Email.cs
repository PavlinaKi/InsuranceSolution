namespace InsuranceSolution.Application.Models.Email
{
    public class Email
    {
        public string Sender { get; set; } = string.Empty;
        public string DistributionGroup { get; set; } = string.Empty;
        public List<string> Recipients { get; set; } = new List<string>();
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}

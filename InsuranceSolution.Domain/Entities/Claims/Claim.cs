namespace InsuranceSolution.Domain.Entities.Claims
{
    public class Claim
    {
        public Guid ClaimId { get; set; }
        public DateTime? AnnouncementDate { get; set; }
        public DateTime? AccidentDate { get; set; }
        public string? ClaimStatus { get; set; } = string.Empty;
        public DateTime? CompensationDate { get; set; }
        public decimal CompensationAmount { get; set; }
        public string? AccidentAddress { get; set; } = string.Empty;
        public string? AccidentRegion { get; set; } = string.Empty;
        public Guid? PolicyId { get; set; }
        public Policy? Policy { get; set; } = null!;
    }
}

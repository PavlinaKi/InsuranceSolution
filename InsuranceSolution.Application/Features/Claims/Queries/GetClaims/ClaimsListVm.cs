namespace InsuranceSolution.Application.Features.Claims.Queries.GetClaims
{
    public class ClaimsListVm
    {
        public string? ClaimId { get; set; } = string.Empty;
        public DateTime? AnnouncementDate { get; set; }
        public DateTime? AccidentDate { get; set; }
        public string? ClaimStatus { get; set; } = string.Empty;
        public DateTime? CompensationDate { get; set; }
        public decimal CompensationAmount { get; set; }
        public string? AccidentAddress { get; set; } = string.Empty;
        public string? AccidentRegion { get; set; } = string.Empty;
    }
}

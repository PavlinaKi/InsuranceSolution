namespace InsuranceSolution.Application.Features.Claims.Queries.GetClaims
{
    public class ClaimsListVm
    {
        public string? ClaimId { get; set; } = string.Empty;
        public DateTime? AnnouncementDate { get; set; }
        public DateTime? AccidentDate { get; set; }
        public string? ClaimStatus { get; set; } = string.Empty;
        public DateTime? CompensationDate { get; set; }
        public Decimal CompensationAmount { get; set; } = 0;
        public string? AccidentAddress { get; set; } = string.Empty;
        public string? AccidentRegion { get; set; } = string.Empty;
        public PolicyVm Policy { get; set; } = default!;
        public CustomerVm Customer { get; set; } = default!;
        public InsurerVm Insurer { get; set; } = default!;
    }
    public class PolicyVm
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

    public class CustomerVm
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty;
    }

    public class InsurerVm
    {
        public string InsurerName { get; set; } = string.Empty;
    }
}

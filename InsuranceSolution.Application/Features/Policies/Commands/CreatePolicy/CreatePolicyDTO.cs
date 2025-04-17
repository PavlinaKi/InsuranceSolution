namespace InsuranceSolution.Application.Features.Policies.Commands.CreatePolicy
{
    public class CreatePolicyDTO
    {
        public Guid PolicyId { get; set; }
        public ePolicySector PolicySector { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string? RenewalNumber { get; set; } = string.Empty;
        public string? AddendumNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public bool? IsCanceled { get; set; }
        public bool? IsExpired { get; set; }
        public string Plates { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
    }
}

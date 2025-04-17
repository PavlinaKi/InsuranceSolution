using InsuranceSolution.Domain.Entities.Claims;

namespace InsuranceSolution.Domain.Entities.Policies
{
    public class Policy
    {
        public ePolicySector PolicySector { get; set; }
        public Guid PolicyId { get; set; }
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
        public ICollection<Claim>? Claim { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; } = null!;

    }
}

namespace InsuranceSolution.Application.Features.Insurers.Queries.GetInsurers
{
    public class InsurersListVm
    {
        public Guid InsurerId { get; set; }
        public string InsurerName { get; set; } = string.Empty;
        public string InsurerCode { get; set; } = string.Empty;
        public List<InsurerEmailDTO>? InsurerEmail { get; set; }
        public List<InsurerPhoneDTO>? InsurerPhone { get; set; }
    }
}

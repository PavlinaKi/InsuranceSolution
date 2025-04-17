namespace InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer
{
    public class CreateInsurerDTO
    {
        public Guid InsurerId { get; set; }
        public string InsurerName { get; set; } = string.Empty;
        public string InsurerCode { get; set; } = string.Empty;
        public List<InsurerEmailDTO>? InsurerEmail { get; set; } = new List<InsurerEmailDTO>();
        public List<InsurerPhoneDTO>? InsurerPhone { get; set; } = new List<InsurerPhoneDTO>();
    }
}

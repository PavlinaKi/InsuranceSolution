namespace InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer
{
    public class InsurerPhoneDTO
    {
        public string? Telephone { get; set; } = string.Empty;
        public ePhoneCategory phoneCategory { get; set; }
    }
}

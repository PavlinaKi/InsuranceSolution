namespace InsuranceSolution.Domain.Entities.Insurers
{
    public class InsurerPhone : AuditableEntity
    {
        public Guid InsurerTelephoneId { get; set; }
        public string? Telephone { get; set; } = string.Empty;
        public ePhoneCategory phoneCategory { get; set; }
        public Guid InsurerId { get; set; }
        public Insurer Insurer { get; set; } = null!;
    }
}

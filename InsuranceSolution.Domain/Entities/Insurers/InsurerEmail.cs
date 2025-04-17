namespace InsuranceSolution.Domain.Entities.Insurers
{
    public class InsurerEmail : AuditableEntity
    {
        public Guid InsurerEmailId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public Guid InsurerId { get; set; }
        public Insurer Insurer { get; set; } = null!;
    }
}

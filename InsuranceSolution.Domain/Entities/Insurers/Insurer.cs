namespace InsuranceSolution.Domain.Entities.Insurers
{
    public class Insurer : AuditableEntity
    {
        public Guid InsurerId { get; set; }
        public string InsurerName { get; set; } = string.Empty;
        public string InsurerCode { get; set; } = string.Empty;
        public ICollection<InsurerEmail>? InsurerEmail { get; set; } = new List<InsurerEmail>();
        public ICollection<InsurerPhone>? InsurerPhone { get; set; } = new List<InsurerPhone>();
        public ICollection<Customer>? Customer { get; set; } = new List<Customer>();
    }
}

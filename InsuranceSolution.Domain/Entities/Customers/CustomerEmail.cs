namespace InsuranceSolution.Domain.Entities.Customers
{
    public class CustomerEmail : AuditableEntity
    {
        public Guid CustomerEmailId { get; set; }
        public string? EmailAddress { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public eEmailType EmailType { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}

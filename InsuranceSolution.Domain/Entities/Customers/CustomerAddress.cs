namespace InsuranceSolution.Domain.Entities.Customers
{
    public class CustomerAddress : AuditableEntity
    {
        public Guid CustomerAddressId { get; set; }
        public string? Prefecture { get; set; } = null;
        public string? City { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? ZipCode { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public eAddressType AddressType { get; set; }
    }
}

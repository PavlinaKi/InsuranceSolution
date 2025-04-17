namespace InsuranceSolution.Domain.Entities.Customers
{
    public class CustomerPhone : AuditableEntity
    {
        public Guid CustomerPhoneId { get; set; }
        public string? Telephone { get; set; } = string.Empty;
        public ePhoneType PhoneType { get; set; }
        public ePhoneCategory PhoneCategory { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public CustomerPhone()
        {
            if (Telephone.StartsWith('6'))
            {
                PhoneCategory = ePhoneCategory.Mobile;
            }
            else
            {
                PhoneCategory = ePhoneCategory.LandLine;
            }
        }
    }
}

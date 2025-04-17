using InsuranceSolution.Domain.Entities.Claims;

namespace InsuranceSolution.Domain.Entities.Customers
{
    public class Customer : AuditableEntity
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; } = null;
        public string? VatNumber { get; set; } = string.Empty;
        public string? SocialSecurityNumber { get; set; } = string.Empty;
        public string? GovernmentID { get; set; } = string.Empty;
        public string? Profession { get; set; } = null;
        public string Nationality { get; set; } = string.Empty;
        public eGender? Gender { get; set; } = null;
        public string? TaxOffice { get; set; } = string.Empty;
        public ICollection<CustomerAddress> CustomerAddress { get; set; } = new List<CustomerAddress>();
        public ICollection<CustomerPhone> CustomerPhone { get; set; } = new List<CustomerPhone>();
        public ICollection<CustomerEmail>? CustomerEmail { get; set; } = new List<CustomerEmail>();
        public ICollection<Policy>? Policies { get; set; }  = new List<Policy>();
        public Guid? InsurerId { get; set; }
        public Insurer? Insurer { get; set; } = null!;

    }
}

namespace InsuranceSolution.Domain.Common
{
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; } = DateTime.Now.ToUniversalTime().ToString();
        public string? LastModifiedBy { get; set; }
        public string? LastModifiedDate { get; set; } = DateTime.Now.ToUniversalTime().ToString();
    }
}

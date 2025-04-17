namespace InsuranceSolution.Application.Features.Policies.Commands.UpdatePolicy
{
    public class UpdatePolicyCommand : IRequest<bool>
    {
        public Guid PolicyId { get; set; }
        public string? RenewalNumber { get; set; } = string.Empty;
        public string? AddendumNumber { get; set; } = string.Empty;
        public bool? IsCanceled { get; set; }
        public bool? IsExpired { get; set; }
        public string Plates { get; set; } = string.Empty;
    }
}

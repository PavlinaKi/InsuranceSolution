namespace InsuranceSolution.Application.Features.Policies.Commands.DeletePolicy
{
    public class DeletePolicyCommand : IRequest
    {
        public Guid PolicyId { get; set; }
    }
}

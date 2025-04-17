namespace InsuranceSolution.Application.Features.Policies.Queries.GetPolicies
{
    public class GetPoliciesQuery :IRequest<List<PoliciesListVm>>
    {
        public Guid customerId { get; set; }
    }
}

namespace InsuranceSolution.Application.Features.Insurers.Queries.GetInsurers
{
    public class GetInsurersQuery : IRequest<List<InsurersListVm>>
    {
        public string policyNumber { get; set; } = string.Empty;
        public string customerVatNumber { get; set; } = string.Empty;
    }
}

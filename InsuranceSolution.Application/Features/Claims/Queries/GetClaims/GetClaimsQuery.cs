namespace InsuranceSolution.Application.Features.Claims.Queries.GetClaims
{
    public class GetClaimsQuery : IRequest<List<ClaimsListVm>>
    {
        public string policyNumber { get; set; } = string.Empty;
    }
}

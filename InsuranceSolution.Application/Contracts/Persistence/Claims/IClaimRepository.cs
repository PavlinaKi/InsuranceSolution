namespace InsuranceSolution.Application.Contracts.Persistence.Claims
{
    public interface IClaimRepository : IAsyncRepository<Claim>
    {
        Task<List<Claim>> GetClaimsListByPolicyNumber(string policyNumber);
    }
}

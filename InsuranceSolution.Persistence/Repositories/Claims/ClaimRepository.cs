namespace InsuranceSolution.Persistence.Repositories.Claims
{
    public class ClaimRepository : BaseRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(InsuranceSolutionDbContext dbContext) : base(dbContext) { }

        public Task<List<Claim>> GetClaimsListByPolicyNumber(string policyNumber)
        {
            var claims = _dbContext.Claim.Where(x=>x.Policy.PolicyNumber.Equals(policyNumber)).ToListAsync();
            return claims;
        }
    }
}

namespace InsuranceSolution.Persistence.Repositories.Insurers
{
    public class InsurerRepository : BaseRepository<Insurer>, IInsurerRepository
    {
        public InsurerRepository(InsuranceSolutionDbContext dbContext) : base(dbContext) { }

        public Task<List<Insurer>> GetPolicyInsurer(string policyNumber, string customerVatNumber)
        {
            //TODO: GetPolicyInsurer
            //var insurer = _dbContext.Insurer
            //                .Where(insurer => insurer.Policies.Any(policy =>
            //                    policy.PolicyNumber == policyNumber &&
            //                    policy.Customer.VatNumber == customerVatNumber))
            //                .ToListAsync();
            //return insurer;
            return null;
        }
    }
}

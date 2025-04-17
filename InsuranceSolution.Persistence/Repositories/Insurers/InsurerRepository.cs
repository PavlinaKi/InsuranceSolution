namespace InsuranceSolution.Persistence.Repositories.Insurers
{
    public class InsurerRepository : BaseRepository<Insurer>, IInsurerRepository
    {
        public InsurerRepository(InsuranceSolutionDbContext dbContext) : base(dbContext) { }

        public async Task<List<Insurer>> GetPolicyInsurer(string policyNumber, string customerVatNumber)
        {
            var insurers = await _dbContext.Insurer
                .Include(i => i.InsurerEmail)
                .Include(i => i.InsurerPhone)
                .Where(insurer => insurer.Customer.Any(customer =>
                     customer.Policies.Any(policy =>
                        policy.PolicyNumber == policyNumber &&
                            customer.VatNumber == customerVatNumber)))
                .ToListAsync();

            return insurers;
        }
    }
}

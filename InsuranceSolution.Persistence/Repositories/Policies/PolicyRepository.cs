namespace InsuranceSolution.Persistence.Repositories.Policies
{
    public class PolicyRepository : BaseRepository<Policy>, IPolicyRepository
    {
        public PolicyRepository(InsuranceSolutionDbContext dbContext) : base(dbContext) { }     
        public Task<List<Policy>> GetPoliciesList(Guid customerId)
        {
            var policies = _dbContext.Policy
           .Where(p => p.Customer.CustomerId == customerId)
           .ToListAsync();

            return policies;
        }
    }
}

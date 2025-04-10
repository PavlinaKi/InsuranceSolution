namespace InsuranceSolution.Persistence.Repositories.Policies
{
    public class PolicyRepository : BaseRepository<Policy>, IPolicyRepository
    {
        public PolicyRepository(InsuranceSolutionDbContext dbContext) : base(dbContext) { }     
        public Task<List<Policy>> GetPoliciesList(DateOnly dateFrom, DateOnly dateTo, string customerVatNumber, int page = 1, int size = 1)
        {
            var fromDate = dateFrom.ToDateTime(TimeOnly.MinValue);
            var toDate = dateTo.ToDateTime(TimeOnly.MaxValue);

            var policies = _dbContext.Policy
           .Where(p => p.StartDate >= fromDate && p.StartDate <= toDate
                       && p.Customer.VatNumber == customerVatNumber)
           .Skip((page - 1) * size)
           .Take(size)
           .AsNoTracking()
           .ToListAsync();

            return policies;
        }
    }
}

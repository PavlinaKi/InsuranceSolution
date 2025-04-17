namespace InsuranceSolution.Persistence.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(InsuranceSolutionDbContext dbContext) : base(dbContext) { }

        public Task<List<Customer>> GetCustomerByVatNumber(string customerVatNumber)
        {
            var customer = _dbContext.Customer.Where(c => c.VatNumber.Equals(customerVatNumber)).ToListAsync();
            return customer;

        }
    }
}

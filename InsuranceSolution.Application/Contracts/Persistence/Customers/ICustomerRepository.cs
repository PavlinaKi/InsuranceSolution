namespace InsuranceSolution.Application.Contracts.Persistence.Customers
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<List<Customer>> GetCustomerByVatNumber(string customerVatNumber);
    }
}

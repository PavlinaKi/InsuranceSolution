namespace InsuranceSolution.Application.Contracts.Persistence.Policies
{
    public interface IPolicyRepository : IAsyncRepository<Policy>
    {
        Task<List<Policy>> GetPoliciesList(Guid customerId);
    }
}

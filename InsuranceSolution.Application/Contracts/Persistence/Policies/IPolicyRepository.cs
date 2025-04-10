namespace InsuranceSolution.Application.Contracts.Persistence.Policies
{
    public interface IPolicyRepository : IAsyncRepository<Policy>
    {
        Task<List<Policy>> GetPoliciesList(DateOnly dateFrom, DateOnly dateTo, string customerVatNumber, int page = 1, int size = 1);
    }
}

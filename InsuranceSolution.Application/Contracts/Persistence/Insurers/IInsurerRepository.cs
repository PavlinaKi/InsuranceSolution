namespace InsuranceSolution.Application.Contracts.Persistence.Insurers
{
    public interface IInsurerRepository : IAsyncRepository<Insurer>
    {
        Task<List<Insurer>> GetPolicyInsurer(string policyNumber, string customerVatNumber);
    }
}

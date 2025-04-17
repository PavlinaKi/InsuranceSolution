namespace InsuranceSolution.Application.Contracts.Infrastructure.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string userEmail, string role);
    }
}

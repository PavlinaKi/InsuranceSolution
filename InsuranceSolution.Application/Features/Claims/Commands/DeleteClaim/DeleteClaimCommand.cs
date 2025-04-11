namespace InsuranceSolution.Application.Features.Claims.Commands.DeleteClaim
{
    public class DeleteClaimCommand : IRequest
    {
        public Guid ClaimId { get; set; }
    }
}

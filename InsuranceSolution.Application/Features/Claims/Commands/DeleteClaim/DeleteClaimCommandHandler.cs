namespace InsuranceSolution.Application.Features.Claims.Commands.DeleteClaim
{
    public class DeleteClaimCommandHandler : IRequestHandler<DeleteClaimCommand>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly ILogger _logger;

        public DeleteClaimCommandHandler (IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public async Task Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var claimToDelete = await _claimRepository.GetByIdAsync(request.ClaimId);

                if (claimToDelete == null)
                {
                    throw new KeyNotFoundException($"Claim with ID {request.ClaimId} was not found.");
                }

                await _claimRepository.DeleteAsync(claimToDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on DeleteClaimCommand for claim id {request.ClaimId}, {ex.Message}");
            }
        }
    }
}

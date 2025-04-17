using InsuranceSolution.Application.Exceptions;

namespace InsuranceSolution.Application.Features.Claims.Commands.DeleteClaim
{
    public class DeleteClaimCommandHandler : IRequestHandler<DeleteClaimCommand>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly ILogger<DeleteClaimCommandHandler> _logger;

        public DeleteClaimCommandHandler(IClaimRepository claimRepository, ILogger<DeleteClaimCommandHandler> logger)
        {
            _claimRepository = claimRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        {
            var claimToDelete = await _claimRepository.GetByIdAsync(request.ClaimId);

            if (claimToDelete == null)
            {
                var error = $"Claim with ID {request.ClaimId} was not found.";
                _logger.LogWarning(error);
                throw new KeyNotFoundException(error);
            }
            await _claimRepository.DeleteAsync(claimToDelete);
        }
    }
}

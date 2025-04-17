namespace InsuranceSolution.Application.Features.Policies.Commands.DeletePolicy
{
    public class DeletePolicyCommandHandler : IRequestHandler<DeletePolicyCommand>
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly ILogger<DeletePolicyCommandHandler> _logger;

        public DeletePolicyCommandHandler(IPolicyRepository policyRepository, ILogger<DeletePolicyCommandHandler> logger)
        {
            _policyRepository = policyRepository;
            _logger = logger;
        }
        public async Task Handle(DeletePolicyCommand request, CancellationToken cancellationToken)
        {
            var policyToDelete = await _policyRepository.GetByIdAsync(request.PolicyId);

            if (policyToDelete == null)
            {
                var error = $"Policy with ID {request.PolicyId} was not found.";
                _logger.LogWarning(error);
                throw new KeyNotFoundException(error);
            }
            await _policyRepository.DeleteAsync(policyToDelete);
        }
    }
}

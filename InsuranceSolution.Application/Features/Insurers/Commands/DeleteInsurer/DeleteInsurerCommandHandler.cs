namespace InsuranceSolution.Application.Features.Insurers.Commands.DeleteInsurer
{
    public class DeleteInsurerCommandHandler : IRequestHandler<DeleteInsurerCommand>
    {
        private readonly IInsurerRepository _insurerRepository;
        private readonly ILogger<DeleteInsurerCommandHandler> _logger;

        public DeleteInsurerCommandHandler(IInsurerRepository insurerRepository, ILogger<DeleteInsurerCommandHandler> logger)
        {
            _insurerRepository = insurerRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteInsurerCommand request, CancellationToken cancellationToken)
        {
            var insurerToDelete = await _insurerRepository.GetByIdAsync(request.InsurerId);

            if (insurerToDelete == null)
            {
                var error = $"Insurer with ID {request.InsurerId} was not found.";
                _logger.LogWarning(error);
                throw new KeyNotFoundException(error);
            }

            await _insurerRepository.DeleteAsync(insurerToDelete);
        }
    }
}

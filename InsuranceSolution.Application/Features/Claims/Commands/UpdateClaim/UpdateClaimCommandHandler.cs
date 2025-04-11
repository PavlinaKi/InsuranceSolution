namespace InsuranceSolution.Application.Features.Claims.Commands.UpdateClaim
{
    public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, bool>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly ILogger<UpdateClaimCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateClaimCommandHandler(IClaimRepository claimRepository, IMapper mapper, ILogger<UpdateClaimCommandHandler> logger)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateClaimCommand request, CancellationToken cancellationToken)
        {
            bool result = false;

            try
            {
                var claimToUpdate = await _claimRepository.GetByIdAsync(request.ClaimId);

                if (claimToUpdate == null)
                {
                    throw new Exception($@"ClaimId {request.ClaimId} Not found");
                }

                //Validation
                var validator = new UpdateClaimCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                {
                    foreach (var ve in validationResult.Errors)
                    {
                        _logger.LogWarning($@"Validation error on UpdateClaimCommand for claim id {request.ClaimId}, {string.Join(",", ve.ErrorMessage)}");
                    }
                    return result;
                }
                else
                {
                    _mapper.Map(request, claimToUpdate, typeof(UpdateClaimCommand), typeof(Claim));
                    await _claimRepository.UpdateAsync(claimToUpdate);
                    result = true;
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($@"Error on UpdateClaimCommand for claim id  {request.ClaimId}, {ex.Message}");
            }

            return result;
        }
    }
}

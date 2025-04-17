namespace InsuranceSolution.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, CreateClaimCommandResponse>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClaimCommandHandler> _logger;

        public CreateClaimCommandHandler(IClaimRepository claimRepository, IMapper mapper, ILogger<CreateClaimCommandHandler> logger)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateClaimCommandResponse> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var createClaimCommandResponse = new CreateClaimCommandResponse();

            try
            {
                var validator = new CreateClaimCommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (validationResult.Errors.Count > 0)
                {
                    createClaimCommandResponse.Success = false;
                    createClaimCommandResponse.ValidationErrors = [];
                    foreach (var error in validationResult.Errors)
                    {
                        createClaimCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogWarning($@"Validation error on CreateClaimCommand for policy id {request.PolicyId}, {string.Join(",", error.ErrorMessage)}");
                    }
                }
                else
                {
                    var claim = _mapper.Map<Claim>(request);
                    claim = await _claimRepository.AddAsync(claim);
                    var claimDTO = _mapper.Map<CreateClaimDTO>(claim);
                    createClaimCommandResponse.Claim = claimDTO;
                    createClaimCommandResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on CreateClaimCommand for policy id {request.PolicyId}, {ex.Message}");
                createClaimCommandResponse.Success = false;
                createClaimCommandResponse.ValidationErrors = [ex.Message];
            }
            return createClaimCommandResponse;
        }
    }
}

namespace InsuranceSolution.Application.Features.Policies.Commands.CreatePolicy
{
    public class CreatePolicyCommandHandler : IRequestHandler<CreatePolicyCommand, CreatePolicyCommandResponse>
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePolicyCommandHandler> _logger;

        public CreatePolicyCommandHandler(IPolicyRepository policyRepository, ILogger<CreatePolicyCommandHandler> logger, IMapper mapper)
        {
            _logger = logger;
            _policyRepository = policyRepository;
            _mapper = mapper;
        }
        public async Task<CreatePolicyCommandResponse> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            var createPolicyCommandResponse = new CreatePolicyCommandResponse();

            try
            {
                var validator = new CreatePolicyCommandValidator();
                var validatorResult = await validator.ValidateAsync(request, cancellationToken);

                if (validatorResult.Errors.Count > 0)
                {
                    createPolicyCommandResponse.Success = false;
                    createPolicyCommandResponse.ValidationErrors = [];
                    foreach (var error in validatorResult.Errors)
                    {
                        createPolicyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogWarning($@"Validation error on CreatePolicyCommand for Policy Number {request.PolicyNumber}, {string.Join(",", error.ErrorMessage)}");
                    }
                }
                else
                {
                    var policy = _mapper.Map<Policy>(request);
                    policy = await _policyRepository.AddAsync(policy);
                    var policyDTO = _mapper.Map<CreatePolicyDTO>(policy);
                    createPolicyCommandResponse.Policy = policyDTO;
                    createPolicyCommandResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on CreatePolicyCommand for Policy Number {request.PolicyNumber}, {ex.Message}");
                createPolicyCommandResponse.Success = false;
                createPolicyCommandResponse.ValidationErrors = [ex.Message];
            }
            return createPolicyCommandResponse;
        }
    }
}

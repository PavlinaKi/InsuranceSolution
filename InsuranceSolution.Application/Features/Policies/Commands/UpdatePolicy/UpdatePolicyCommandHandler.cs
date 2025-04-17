namespace InsuranceSolution.Application.Features.Policies.Commands.UpdatePolicy
{
    public class UpdatePolicyCommandHandler : IRequestHandler<UpdatePolicyCommand, bool>
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly ILogger<UpdatePolicyCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdatePolicyCommandHandler(IPolicyRepository policyRepository, ILogger<UpdatePolicyCommandHandler> logger, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePolicyCommand request, CancellationToken cancellationToken)
        {
            bool result = false;

            try
            {
                var policyToUpdate = await _policyRepository.GetByIdAsync(request.PolicyId);

                if (policyToUpdate == null) 
                {
                    throw new Exception($@"PolicyId {request.PolicyId} Not found");
                }

                //Validation
                var validator = new UpdatePolicyCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                {
                    foreach (var ve in validationResult.Errors)
                    {
                        _logger.LogWarning($@"Validation error on UpdatePolicyCommand for claim id {request.PolicyId}, {string.Join(",", ve.ErrorMessage)}");
                    }
                    return result;
                }
                else
                {
                    _mapper.Map(request, policyToUpdate, typeof(UpdatePolicyCommand), typeof(Policy));
                    await _policyRepository.UpdateAsync(policyToUpdate);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on UpdatePolicyCommand for policy id  {request.PolicyId}, {ex.Message}");
            }

            return result;
        }
    }
}

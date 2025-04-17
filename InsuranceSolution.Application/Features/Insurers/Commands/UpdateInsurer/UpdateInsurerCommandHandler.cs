namespace InsuranceSolution.Application.Features.Insurers.Commands.UpdateInsurer
{
    public class UpdateInsurerCommandHandler : IRequestHandler<UpdateInsurerCommand, bool>
    {

        private readonly IInsurerRepository _insurerRepository;
        private readonly ILogger<UpdateInsurerCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateInsurerCommandHandler(IInsurerRepository insurerRepository, IMapper mapper, ILogger<UpdateInsurerCommandHandler> logger)
        {
            _insurerRepository = insurerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateInsurerCommand request, CancellationToken cancellationToken)
        {
            bool result = false;

            try
            {
                var insurerToUpdate = await _insurerRepository.GetByIdAsync(request.InsurerId);

                if (insurerToUpdate == null)
                {
                    throw new Exception($@"InsurerId {request.InsurerId} Not found");
                }

                //Validation
                var validator = new UpdateInsurerCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                {
                    foreach (var ve in validationResult.Errors)
                    {
                        _logger.LogWarning($@"Validation error on UpdateInsurerCommand for insurer id {request.InsurerId}, {string.Join(",", ve.ErrorMessage)}");
                    }
                    return result;
                }
                else
                {
                    _mapper.Map(request, insurerToUpdate, typeof(UpdateInsurerCommand), typeof(Insurer));
                    await _insurerRepository.UpdateAsync(insurerToUpdate);
                    result = true;
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($@"Error on UpdateClaimCommand for insurer id  {request.InsurerId}, {ex.Message}");
            }

            return result;
        }
    }
}

namespace InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer
{
    public class CreateInsurerCommandHandler : IRequestHandler<CreateInsurerCommand, CreateInsurerCommandResponse>
    {
        private readonly IInsurerRepository _insurerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInsurerCommandHandler> _logger;

        public CreateInsurerCommandHandler(IInsurerRepository insurerRepository, IMapper mapper, ILogger<CreateInsurerCommandHandler> logger)
        {
            _insurerRepository = insurerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateInsurerCommandResponse> Handle(CreateInsurerCommand request, CancellationToken cancellationToken)
        {
            var createInsurerCommandResponse = new CreateInsurerCommandResponse();

            try
            {
                var validator = new CreateInsurerCommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (validationResult.Errors.Any())
                {
                    createInsurerCommandResponse.Success = false;
                    createInsurerCommandResponse.ValidationErrors = [];
                    foreach (var error in validationResult.Errors)
                    {
                        createInsurerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogWarning($@"Validation error on CreateInsurerCommand for insurer name {request.InsurerName}, {string.Join(",", error.ErrorMessage)}");
                    }
                }
                else
                {
                    var insurer = _mapper.Map<Insurer>(request);
                    insurer = await _insurerRepository.AddAsync(insurer);
                    var insurerDTO = _mapper.Map<CreateInsurerDTO>(insurer);
                    createInsurerCommandResponse.CreateInsurer = insurerDTO;
                    createInsurerCommandResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on CreateInsurerCommand for insurer name {request.InsurerName}, {ex.Message}");
                createInsurerCommandResponse.Success = false;
                createInsurerCommandResponse.ValidationErrors = [ex.Message];

            }

            return createInsurerCommandResponse;
        }
    }
}

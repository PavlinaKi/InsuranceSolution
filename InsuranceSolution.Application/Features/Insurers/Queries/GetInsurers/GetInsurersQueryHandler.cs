namespace InsuranceSolution.Application.Features.Insurers.Queries.GetInsurers
{
    public class GetInsurersQueryHandler : IRequestHandler<GetInsurersQuery, List<InsurersListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IInsurerRepository _insurerRepository;
        private readonly ILogger<GetInsurersQueryHandler> _logger;

        public GetInsurersQueryHandler(IMapper mapper, IInsurerRepository insurerRepository, ILogger<GetInsurersQueryHandler> logger)
        {
            _mapper = mapper;
            _insurerRepository = insurerRepository;
            _logger = logger;
        }

        public async Task<List<InsurersListVm>> Handle(GetInsurersQuery request, CancellationToken cancellationToken)
        {
            var insurer = await _insurerRepository.GetPolicyInsurer(request.policyNumber, request.customerVatNumber);
            var insurersVm = _mapper.Map<List<InsurersListVm>>(insurer);




            return insurersVm;
        }
    }
}

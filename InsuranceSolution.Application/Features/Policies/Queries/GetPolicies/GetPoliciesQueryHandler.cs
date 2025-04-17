namespace InsuranceSolution.Application.Features.Policies.Queries.GetPolicies
{
    public class GetPoliciesQueryHandler : IRequestHandler<GetPoliciesQuery, List<PoliciesListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPolicyRepository _policiesRepository;
        private readonly ILogger<GetPoliciesQueryHandler> _logger;

        public GetPoliciesQueryHandler(IMapper mapper, IPolicyRepository policiesRepository, ILogger<GetPoliciesQueryHandler> logger)
        {
            _mapper = mapper;
            _policiesRepository = policiesRepository;
            _logger = logger;
        }

        public async Task<List<PoliciesListVm>> Handle(GetPoliciesQuery request, CancellationToken cancellationToken)
        {
            var policies = await _policiesRepository.GetPoliciesList(request.customerId);
            var policiesVm = _mapper.Map<List<PoliciesListVm>>(policies);
            return policiesVm;

        }
    }
}

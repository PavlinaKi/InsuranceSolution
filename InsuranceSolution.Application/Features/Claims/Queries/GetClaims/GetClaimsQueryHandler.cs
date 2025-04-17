namespace InsuranceSolution.Application.Features.Claims.Queries.GetClaims
{
    public class GetClaimsQueryHandler : IRequestHandler<GetClaimsQuery, List<ClaimsListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IClaimRepository _claimsRepository;
        private readonly ILogger<GetClaimsQueryHandler> _logger;

        public GetClaimsQueryHandler(IMapper mapper, IClaimRepository claimsRepository, ILogger<GetClaimsQueryHandler> logger)
        {
            _mapper = mapper;
            _claimsRepository = claimsRepository;
            _logger = logger;
        }

        public async Task<List<ClaimsListVm>> Handle(GetClaimsQuery request, CancellationToken cancellationToken)
        {
            var claims = await _claimsRepository.GetClaimsListByPolicyNumber(request.policyNumber);
            var claimsVm = _mapper.Map<List<ClaimsListVm>>(claims);
            return claimsVm;
        }
    }
}

using InsuranceSolution.Application.Features.Claims.Queries.GetClaims;

namespace InsuranceSolution.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Claim, ClaimsListVm>()
            .ForMember(dest => dest.ClaimId, opt => opt.MapFrom(src => src.ClaimId.ToString()))
            .ForMember(dest => dest.Policy, opt => opt.MapFrom(src => src.Policy));

            CreateMap<Policy, PolicyVm>();
            CreateMap<Customer, CustomerVm>();
            CreateMap<Insurer, InsurerVm>();
        }
    }
}

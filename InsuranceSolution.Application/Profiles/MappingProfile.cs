using InsuranceSolution.Application.Features.Claims.Commands.DeleteClaim;
using InsuranceSolution.Application.Features.Claims.Commands.UpdateClaim;

namespace InsuranceSolution.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Claims
            CreateMap<Claim, ClaimsListVm>().ReverseMap();
            CreateMap<Claim, CreateClaimDTO>().ReverseMap();
            CreateMap<Claim, CreateClaimCommand>().ReverseMap();
            CreateMap<Claim, UpdateClaimCommand>().ReverseMap();
            CreateMap<Claim, DeleteClaimCommand>().ReverseMap();


            //Policies
            //CreateMap<Policy, PolicyVm>().ReverseMap();

            //Customers
            //CreateMap<Customer, CustomerVm>().ReverseMap();

            //Insurers
            //CreateMap<Insurer, InsurerVm>().ReverseMap();
        }
    }
}

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
            CreateMap<Policy, PoliciesListVm>().ReverseMap();
            CreateMap<Policy, CreatePolicyDTO>().ReverseMap();
            CreateMap<Policy, CreatePolicyCommand>().ReverseMap();
            CreateMap<Policy, UpdatePolicyCommand>().ReverseMap();
            CreateMap<Policy, DeletePolicyCommand>().ReverseMap();

            //Customers
            //CreateMap<Customer, CustomerVm>().ReverseMap();

            //Insurers
            CreateMap<CreateInsurerDTO, Insurer>().ReverseMap()
           .ForMember(dest => dest.InsurerEmail, opt => opt.MapFrom(src => src.InsurerEmail))
           .ForMember(dest => dest.InsurerPhone, opt => opt.MapFrom(src => src.InsurerPhone));

            CreateMap<CreateInsurerCommand, Insurer>().ReverseMap()
           .ForMember(dest => dest.InsurerEmail, opt => opt.MapFrom(src => src.InsurerEmail))
           .ForMember(dest => dest.InsurerPhone, opt => opt.MapFrom(src => src.InsurerPhone));

            CreateMap<InsurerEmailDTO, InsurerEmail>().ReverseMap();
            CreateMap<InsurerPhoneDTO, InsurerPhone>().ReverseMap();

            CreateMap<Insurer, InsurersListVm>().ReverseMap();
            CreateMap<Insurer, UpdateInsurerCommand>().ReverseMap();
            CreateMap<Insurer, DeleteInsurerCommand>().ReverseMap();
        }
    }
}

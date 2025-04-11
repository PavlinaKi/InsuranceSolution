namespace InsuranceSolution.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandResponse : BaseResponse
    {
        public CreateClaimCommandResponse() : base() { }

        public CreateClaimDTO Claim { get; set; }
    }
}

namespace InsuranceSolution.Application.Features.Policies.Commands.CreatePolicy
{
    public class CreatePolicyCommandResponse : BaseResponse
    {
        public CreatePolicyCommandResponse() :base() { }

        public CreatePolicyDTO Policy { get; set; }
    }
}

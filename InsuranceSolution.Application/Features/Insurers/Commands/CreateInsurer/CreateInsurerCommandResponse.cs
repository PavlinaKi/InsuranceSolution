namespace InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer
{
    public class CreateInsurerCommandResponse : BaseResponse
    {
        public CreateInsurerCommandResponse() : base() { }

        public CreateInsurerDTO CreateInsurer { get; set; }
    }
}

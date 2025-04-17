namespace InsuranceSolution.Application.Features.Insurers.Commands.DeleteInsurer
{
    public class DeleteInsurerCommand : IRequest
    {
        public Guid InsurerId { get; set; }
    }
}

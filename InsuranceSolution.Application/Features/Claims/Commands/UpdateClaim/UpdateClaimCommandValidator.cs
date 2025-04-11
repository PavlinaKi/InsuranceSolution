namespace InsuranceSolution.Application.Features.Claims.Commands.UpdateClaim
{
    public class UpdateClaimCommandValidator : AbstractValidator<UpdateClaimCommand>
    {
        public UpdateClaimCommandValidator()
        {
            RuleFor(n => n.AnnouncementDate)
               .NotEmpty().WithMessage("AnnouncementDate is required.")
               .NotNull()
               ;

            RuleFor(n => n.AccidentDate)
               .NotEmpty().WithMessage("AccidentDate is required.")
               .NotNull()
               ;

            RuleFor(n => n.ClaimStatus)
               .NotEmpty().WithMessage("ClaimStatus is required.")
               .NotNull()
               ;

            RuleFor(n => n.CompensationDate)
              .NotEmpty().WithMessage("CompensationDate is required.")
              .NotNull()
              ;

            RuleFor(n => n.CompensationAmount)
               .NotEmpty().WithMessage("CompensationAmount is required.")
               .NotNull()
               ;

            RuleFor(n => n.AccidentAddress)
               .NotEmpty().WithMessage("AccidentAddress is required.")
               .NotNull()
                ;

            RuleFor(n => n.AccidentRegion)
               .NotEmpty().WithMessage("AccidentRegion is required.")
               .NotNull()
                ;
        }
    }
}

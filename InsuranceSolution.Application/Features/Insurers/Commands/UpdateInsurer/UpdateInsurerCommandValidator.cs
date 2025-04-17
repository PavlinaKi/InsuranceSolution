namespace InsuranceSolution.Application.Features.Insurers.Commands.UpdateInsurer
{
    public class UpdateInsurerCommandValidator : AbstractValidator<UpdateInsurerCommand>
    {
        public UpdateInsurerCommandValidator() 
        {
            RuleFor(x => x.InsurerName)
            .NotNull().WithMessage("InsurerName is required.")
            .NotEmpty().WithMessage("InsurerName cannot be empty.")
            .MaximumLength(50).WithMessage("InsurerName must not exceed 50 characters.");

            RuleFor(x => x.InsurerCode)
               .NotNull().WithMessage("InsurerCode is required.")
               .NotEmpty().WithMessage("InsurerCode cannot be empty.")
               .MaximumLength(6).WithMessage("InsurerCode must not exceed 6 characters.");

            // Validate each email item in the list
            RuleForEach(x => x.InsurerEmail)
                .SetValidator(new InsurerEmailDTOValidator());

            // Validate each phone item in the list
            RuleForEach(x => x.InsurerPhone)
                .SetValidator(new InsurerPhoneDTOValidator());


        }
    }
}

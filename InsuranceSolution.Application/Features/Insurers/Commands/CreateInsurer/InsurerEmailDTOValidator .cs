namespace InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer
{
    public class InsurerEmailDTOValidator : AbstractValidator<InsurerEmailDTO>
    {
        public InsurerEmailDTOValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("Email address is required.")
                .MaximumLength(50).WithMessage("Email address must not exceed 50 characters.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}

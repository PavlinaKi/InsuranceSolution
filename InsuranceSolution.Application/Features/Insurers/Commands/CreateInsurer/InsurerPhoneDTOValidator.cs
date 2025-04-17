namespace InsuranceSolution.Application.Features.Insurers.Commands.CreateInsurer
{
    public class InsurerPhoneDTOValidator : AbstractValidator<InsurerPhoneDTO>
    {
        public InsurerPhoneDTOValidator()
        {
            RuleFor(x => x.Telephone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(10).WithMessage("Phone number must not exceed 10 digits.");

            RuleFor(x => x.phoneCategory)
                 .Must(value => Enum.IsDefined(typeof(ePhoneCategory), value))
                 .WithMessage("Invalid phone category.");
        }
    }
}

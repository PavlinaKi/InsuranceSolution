namespace InsuranceSolution.Application.Features.Policies.Commands.UpdatePolicy
{
    public class UpdatePolicyCommandValidator : AbstractValidator<UpdatePolicyCommand>
    {
        public UpdatePolicyCommandValidator()
        {
            RuleFor(x => x.RenewalNumber)
                .MaximumLength(11).WithMessage("Renewal Number must not exceed 11 characters.");

            RuleFor(x => x.AddendumNumber)
                .MaximumLength(11).WithMessage("Addendum Number must not exceed 11 characters.");

            RuleFor(x => x.Plates)
                .NotEmpty().WithMessage("Plates are required.")
                .MaximumLength(7).WithMessage("Plates must not exceed 7 characters.");
        }
    }
}

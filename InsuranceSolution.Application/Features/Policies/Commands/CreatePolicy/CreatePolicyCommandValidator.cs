namespace InsuranceSolution.Application.Features.Policies.Commands.CreatePolicy
{
    public class CreatePolicyCommandValidator : AbstractValidator<CreatePolicyCommand>
    {
        public CreatePolicyCommandValidator()
        {
            RuleFor(x => x.PolicySector)
                .IsInEnum().WithMessage("Invalid policy sector selected.");

            RuleFor(x => x.PolicyNumber)
                .NotNull().WithMessage("Policy Number is required.")
                .NotEmpty().WithMessage("Policy Number cannot be empty.")
                .MaximumLength(11).WithMessage("Policy Number must not exceed 11 characters.");

            RuleFor(x => x.RenewalNumber)
                .MaximumLength(11).WithMessage("Renewal Number must not exceed 11 characters.");

            RuleFor(x => x.AddendumNumber)
                .MaximumLength(11).WithMessage("Addendum Number must not exceed 11 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start Date is required.")
                .Must(BeUtc).WithMessage("Start Date must be in UTC.")
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be before or equal to End Date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End Date is required.")
                .Must(BeUtc).WithMessage("End Date must be in UTC.");

            RuleFor(x => x.NetPrice)
                 .GreaterThan(0).WithMessage("Net Price must be greater than 0.");

            RuleFor(x => x.GrossPrice)
                .GreaterThan(0).WithMessage("Gross Price must be greater than 0.");

            RuleFor(x => x.Plates)
                .NotEmpty().WithMessage("Plates are required.")
                .MaximumLength(7).WithMessage("Plates must not exceed 7 characters.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");
        }

            private bool BeUtc(DateTime date)
        {
            return date.Kind == DateTimeKind.Utc;
        }
    }
}


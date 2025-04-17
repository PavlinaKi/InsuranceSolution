namespace InsuranceSolution.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandValidator : AbstractValidator<CreateClaimCommand>
    {
        public CreateClaimCommandValidator()
        {
            RuleFor(x => x.AnnouncementDate)
                .NotNull().WithMessage("Announcement date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Announcement date cannot be in the future.");

            RuleFor(x => x.AccidentDate)
                .NotNull().WithMessage("Accident date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Accident date cannot be in the future.")
                .LessThanOrEqualTo(x => x.AnnouncementDate).WithMessage("Accident date must be earlier than or equal to the announcement date.");

            RuleFor(x => x.ClaimStatus)
                .NotNull().WithMessage("Claim status is required.")
                .NotEmpty().WithMessage("Claim status cannot be empty.")
                .MaximumLength(50).WithMessage("Claim status must not exceed 50 characters.");

            RuleFor(x => x.CompensationDate)
                .GreaterThanOrEqualTo(x => x.AccidentDate)
                .When(x => x.CompensationDate.HasValue && x.AccidentDate.HasValue)
                .WithMessage("Compensation date must be after the accident date.");

            RuleFor(x => x.CompensationAmount)
                .NotNull().WithMessage("Compensation amount is required.")
                .GreaterThan(0).WithMessage("Compensation amount must be greater than 0.");

            RuleFor(x => x.AccidentAddress)
                .NotEmpty().WithMessage("Accident address is required.")
                .MaximumLength(100).WithMessage("Accident address must not exceed 100 characters.");

            RuleFor(x => x.AccidentRegion)
                .NotEmpty().WithMessage("Accident region is required.")
                .MaximumLength(100).WithMessage("Accident region must not exceed 100 characters.");

            RuleFor(x => x.PolicyId)
                .NotEmpty().WithMessage("Policy ID is required.");
        }
    }
}

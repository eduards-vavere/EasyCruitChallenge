using EasyCruitChallenge.Models;
using FluentValidation;
using FluentValidation.Results;

namespace EasyCruitChallenge.Validation
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(m => m.FirstName).NotNull().WithMessage("Please specify a first name.");
            RuleFor(m => m.LastName).NotNull().WithMessage("Please specify a last name.");
            RuleFor(m => m.Email).NotNull().WithMessage("Please specify an email.");
            RuleFor(m => m.MotivationLetterText).NotNull().WithMessage("Please specify a motivational letter.");

            RuleFor(m => m.FirstName).MaximumLength(32).WithMessage("Max length for first name is 32.");
            RuleFor(m => m.LastName).MaximumLength(32).WithMessage("Max length for last name is 32.");
            RuleFor(m => m.Email).MaximumLength(64).WithMessage("Max length for email is 64.");
            RuleFor(m => m.MotivationLetterText).MaximumLength(256).WithMessage("Max length for motivational letter is 256.");

            RuleFor(m => m.Email).EmailAddress().WithMessage("Please specify a correct email address.");
        }

        protected override bool PreValidate(ValidationContext<Candidate> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please submit a non-null model."));

                return false;
            }
            return true;
        }
    }
}

using System.Collections.Generic;
using EasyCruitChallenge.Models;
using FluentValidation.Results;

namespace EasyCruitChallenge.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this Candidate candidate, out IEnumerable<string> errors)
        {
            var validator = new CandidateValidator();

            var validationResult = validator.Validate(candidate);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}

using FluentValidation;
using FluentValidationExemple.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationExemple.Validator
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().Length(1, 50)
                .WithMessage("Full name is required and needs to be greater than 1 and lower than 50");

            RuleFor(p => p.Age).NotEmpty()
                .InclusiveBetween(18, 50)
                .WithMessage("The min age is 18 and max age is 50");

            RuleFor(p => p.Discount).NotEmpty().GreaterThan(0)
                .LessThanOrEqualTo(100)
                .When(x => x.HasDiscount)
                .WithMessage("The % discount is invalid");

            RuleFor(p => p.DateOfBirth).Must(ValidDateOfBirth)
                .WithMessage("The date of birth is invalid.");
        }

        private bool ValidDateOfBirth(DateTime dateOfBirth)
        {
            // Owner logic
            return (dateOfBirth <= DateTime.Today.AddYears(-18));
        }
    }
}

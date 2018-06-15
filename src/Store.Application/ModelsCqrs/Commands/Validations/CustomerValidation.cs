using FluentValidation;
using Store.DomainShared.FinalValues;
using System;

namespace Store.Application.ModelsCqrs.Commands.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("Please ensure you have entered the First Name")
                .Length(CustomerConsts.FirstNameMinLength, CustomerConsts.FirstNameMaxLength)
                .WithMessage("The First Name must have between 2 and 150 characters");
        }

        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the Last Name")
                .Length(CustomerConsts.LastNameMinLength, CustomerConsts.LastNameMaxLength).WithMessage("The Last Name must have between 2 and 150 characters");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.AddressEmail)
                .NotEmpty()
                .MaximumLength(CustomerConsts.EmailMaxLength)
                .EmailAddress();
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}

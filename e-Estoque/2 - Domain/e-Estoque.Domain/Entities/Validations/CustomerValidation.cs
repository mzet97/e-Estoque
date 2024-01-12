using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(r => r.Name)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.DocId)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 50).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Email)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 100).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Description)
              .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
              .Length(3, 5000).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.PhoneNumber)
              .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
              .Length(3, 15).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.IdCustomerAddress)
                .NotNull().WithMessage("The {PropertyName} needs to be provided");
        }
    }
}
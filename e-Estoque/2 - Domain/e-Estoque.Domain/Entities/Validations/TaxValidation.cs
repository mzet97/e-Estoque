using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class TaxValidation : AbstractValidator<Tax>
    {
        public TaxValidation()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(2, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(p => p.Percentage)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(2, 5000).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");
        }
    }
}
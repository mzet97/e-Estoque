using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(r => r.Name)
              .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
              .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Description)
              .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
              .Length(3, 5000).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.ShortDescription)
              .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
              .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Price)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .GreaterThan(0).WithMessage("The {PropertyName} needs to be greater 0");

            RuleFor(r => r.Height)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .GreaterThan(0).WithMessage("The {PropertyName} needs to be greater 0");

            RuleFor(r => r.Length)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .GreaterThan(0).WithMessage("The {PropertyName} needs to be greater 0");

            RuleFor(r => r.IdCategory)
                .NotNull().WithMessage("The {PropertyName} needs to be provided");

            RuleFor(r => r.IdCompany)
                .NotNull().WithMessage("The {PropertyName} needs to be provided");
        }
    }
}
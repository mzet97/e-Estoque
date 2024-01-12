using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(2, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.ShortDescription)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(2, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
                .Length(2, 5000).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");
        }
    }
}
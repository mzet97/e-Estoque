using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class AdressValidation : AbstractValidator<Adress>
    {
        public AdressValidation()
        {
            RuleFor(r => r.Street)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Number)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(1, 5).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Complement)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Neighborhood)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.District)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.City)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.County)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.ZipCode)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Latitude)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");

            RuleFor(r => r.Longitude)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .Length(3, 250).WithMessage("The {PropertyName} need to have between {MinLength} and {MaxLength} characters");
        }
    }
}

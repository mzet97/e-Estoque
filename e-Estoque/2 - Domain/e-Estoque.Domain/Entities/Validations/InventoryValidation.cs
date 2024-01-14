using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class InventoryValidation : AbstractValidator<Inventory>
    {
        public InventoryValidation()
        {
            RuleFor(r => r.Quantity)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .GreaterThan(0).WithMessage("The {PropertyName} needs to be greater than {ComparisonValue}");

            RuleFor(r => r.DateOrder)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");

            RuleFor(r => r.IdProduct)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");
        }
    }
}

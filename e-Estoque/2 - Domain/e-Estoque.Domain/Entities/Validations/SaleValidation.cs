using FluentValidation;

namespace e_Estoque.Domain.Entities.Validations
{
    public class SaleValidation : AbstractValidator<Sale>
    {
        public SaleValidation()
        {
            RuleFor(r => r.Quantity)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided")
               .GreaterThan(0).WithMessage("The {PropertyName} needs to be greater than {ComparisonValue}");

            RuleFor(r => r.SaleType)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");

            RuleFor(r => r.PaymentType)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");

            RuleFor(r => r.SaleDate)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");

            RuleFor(r => r.IdCustomer)
               .NotEmpty().WithMessage("The {PropertyName} needs to be provided");
        }
    }
}

using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Data;
using FluentValidation;
using FluentValidation.Results;

namespace e_Estoque.Service
{
    public abstract class BaseService
    {
        protected readonly INotifier _notifier;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(
            INotifier notifier,
            IUnitOfWork unitOfWork)
        {
            _notifier = notifier;
            _unitOfWork = unitOfWork;
        }

        protected void NotifyError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotifyError(error.ErrorMessage, NotificationType.ERROR);
            }
        }

        protected void NotifyError(string mensagem, NotificationType type)
        {
            _notifier.Handle(new Notification(mensagem, type));
        }

        protected bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            NotifyError(validator);

            return false;
        }
    }
}
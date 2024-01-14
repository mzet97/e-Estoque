using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public async Task Create(Customer entity)
        {
            if (!Validate(new CustomerValidation(), entity))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            if (!Validate(new AddressValidation(), entity.CustomerAddress as Address))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.CustomerRepository.Create(entity);

            await _unitOfWork.RepositoryFactory.CustomerRepository.Commit();
        }

        public async Task<IEnumerable<Customer>> Find(Expression<Func<Customer, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.CustomerRepository.Find(predicate);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.CustomerRepository.GetAll();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.CustomerRepository.GetById(id);
        }

        public async Task Remove(Guid id, Customer entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Company invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Company não encontrada", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.CustomerRepository.Remove(id);

            await _unitOfWork.RepositoryFactory.CompanyRepository.Commit();
        }

        public async Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.CustomerRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public async Task Update(Guid id, Customer entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Company invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new CustomerValidation(), entity))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            if (!Validate(new AddressValidation(), entity.CustomerAddress as Address))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            _unitOfWork.RepositoryFactory.CustomerRepository.Update(entity);

            await _unitOfWork.RepositoryFactory.CustomerRepository.Commit();
        }
    }
}
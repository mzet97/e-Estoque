using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public async Task Create(Company entity)
        {
            if (!Validate(new CompanyValidation(), entity))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            if (!Validate(new AddressValidation(), entity.CompanyAddress as Address))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.CompanyRepository.Create(entity);

            var result = await _unitOfWork.RepositoryFactory.CompanyRepository.Commit();
        }

        public async Task<IEnumerable<Company>> Find(Expression<Func<Company, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.CompanyRepository.Find(predicate);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.CompanyRepository.GetAll();
        }

        public async Task<Company> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.CompanyRepository.GetById(id);
        }

        public async Task Remove(Guid id, Company entity)
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

            _unitOfWork.RepositoryFactory.CompanyRepository.Update(entity);

            var result = await _unitOfWork.RepositoryFactory.CompanyRepository.Commit();
        }

        public async Task<IEnumerable<Company>> Search(Expression<Func<Company, bool>> predicate = null, Func<IQueryable<Company>, IOrderedQueryable<Company>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.CompanyRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public async Task Update(Guid id, Company entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Company invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new CompanyValidation(), entity))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            if (!Validate(new AddressValidation(), entity.CompanyAddress as Address))
            {
                _notifier.Handle("Company não está valida!", NotificationType.ERROR);
                return;
            }

            _unitOfWork.RepositoryFactory.CompanyRepository.Update(entity);

            var result = await _unitOfWork.RepositoryFactory.CompanyRepository.Commit();
        }
    }
}
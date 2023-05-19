using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class TaxService : BaseService, ITaxService
    {
        private readonly ILogger<TaxService> _logger;

        public TaxService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            ILogger<TaxService> logger) : base(notifier, unitOfWork)
        {
            _logger = logger;
        }

        public async Task Create(Tax entity)
        {

            if (!Validate(new TaxValidation(), entity))
            {
                _notifier.Handle("Tax não está valida!", NotificationType.ERROR);
                return;
            }

            var category = await _unitOfWork.RepositoryFactory.CategoryRepository.GetById(entity.IdCategory);

            if (category == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Category = null;


            await _unitOfWork.RepositoryFactory.TaxRepository.Create(entity);

            var result = await _unitOfWork.RepositoryFactory.TaxRepository.Commit();

        }

        public async Task<IEnumerable<Tax>> Find(Expression<Func<Tax, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.TaxRepository.Find(predicate);
        }

        public async Task<IEnumerable<Tax>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.TaxRepository.GetAll();
        }

        public async Task<Tax> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.TaxRepository.GetById(id);
        }

        public async Task Remove(Guid id, Tax entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Tax invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Tax não encontrada", NotificationType.ERROR);
                return;
            }

            _unitOfWork.RepositoryFactory.TaxRepository.Update(entity);

            var result = await _unitOfWork.RepositoryFactory.TaxRepository.Commit();
        }

        public async Task<IEnumerable<Tax>> Search(Expression<Func<Tax, bool>> predicate = null, Func<IQueryable<Tax>, IOrderedQueryable<Tax>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.TaxRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public async Task Update(Guid id, Tax entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Tax invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new TaxValidation(), entity))
            {
                _notifier.Handle("Tax não está valida!", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Tax não encontrada", NotificationType.ERROR);
                return;
            }

            var category = await _unitOfWork.RepositoryFactory.CategoryRepository.GetById(entity.IdCategory);

            if (category == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Category = null;

            _unitOfWork.RepositoryFactory.TaxRepository.Update(entity);

            var result = await _unitOfWork.RepositoryFactory.TaxRepository.Commit();
        }
    }
}

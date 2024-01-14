using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class InventoryService : BaseService, IInventoryService
    {
        public InventoryService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public async Task Create(Inventory entity)
        {
            if (!Validate(new InventoryValidation(), entity))
            {
                _notifier.Handle("Invetario não está valida!", NotificationType.ERROR);
                return;
            }

            var product = await _unitOfWork
                .RepositoryFactory
                .ProductRepository
                .GetById(entity.IdProduct);

            if (product == null)
            {
                _notifier.Handle("Product não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Product = null;

            await _unitOfWork
                .RepositoryFactory
                .InventoryRepository
                .Create(entity);

            await _unitOfWork
                .RepositoryFactory
                .InventoryRepository
                .Commit();
        }

        public async Task<IEnumerable<Inventory>> Find(Expression<Func<Inventory, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.InventoryRepository.Find(predicate);
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.InventoryRepository.GetAll();
        }

        public async Task<Inventory> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.InventoryRepository.GetById(id);
        }

        public async Task Remove(Guid id, Inventory entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Inventory invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Inventory não encontrada", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.InventoryRepository.Remove(id);

            await _unitOfWork.RepositoryFactory.InventoryRepository.Commit();
        }

        public async Task<IEnumerable<Inventory>> Search(Expression<Func<Inventory, bool>> predicate = null, Func<IQueryable<Inventory>, IOrderedQueryable<Inventory>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.InventoryRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public async Task Update(Guid id, Inventory entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Inventory invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new InventoryValidation(), entity))
            {
                _notifier.Handle("Inventory não está valida!", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Inventory não encontrada", NotificationType.ERROR);
                return;
            }

            var product = await _unitOfWork.RepositoryFactory.ProductRepository.GetById(entity.IdProduct);

            if (product == null)
            {
                _notifier.Handle("Product não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Product = null;


            _unitOfWork.RepositoryFactory.InventoryRepository.Update(entity);

            await _unitOfWork.RepositoryFactory.InventoryRepository.Commit();
        }
    }
}
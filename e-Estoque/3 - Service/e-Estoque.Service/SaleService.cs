using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class SaleService : BaseService, ISaleService
    {
        private readonly ISaleProductService _saleProductService;

        public SaleService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            ISaleProductService saleProductService) : base(notifier, unitOfWork)
        {
            _saleProductService = saleProductService;
        }

        public async Task Create(Sale entity)
        {
            if (!Validate(new SaleValidation(), entity))
            {
                _notifier.Handle("Sale não está valida!", NotificationType.ERROR);
                return;
            }

            var customer = await _unitOfWork
                .RepositoryFactory
                .CustomerRepository
                .GetById(entity.IdCustomer);

            if (customer == null)
            {
                _notifier.Handle("Customer não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Customer = null;

            await _unitOfWork
                .RepositoryFactory
                .SaleRepository
                .Create(entity);

            await _unitOfWork
                .RepositoryFactory
                .SaleRepository
                .Commit();

            await _saleProductService.Create(entity.SaleProduct);
        }

        public async Task<IEnumerable<Sale>> Find(Expression<Func<Sale, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.SaleRepository.Find(predicate);
        }

        public async Task<IEnumerable<Sale>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.SaleRepository.GetAll();
        }

        public async Task<Sale> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.SaleRepository.GetById(id);
        }

        public async Task Remove(Guid id, Sale entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Sale invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Sale não encontrada", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.SaleRepository.Remove(id);

            await _unitOfWork.RepositoryFactory.SaleRepository.Commit();
        }

        public async Task<IEnumerable<Sale>> Search(Expression<Func<Sale, bool>> predicate = null, Func<IQueryable<Sale>, IOrderedQueryable<Sale>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.SaleRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public async Task Update(Guid id, Sale entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Sale invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new SaleValidation(), entity))
            {
                _notifier.Handle("Sale não está valida!", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Sale não encontrada", NotificationType.ERROR);
                return;
            }

            var customer = await _unitOfWork.RepositoryFactory.CustomerRepository.GetById(entity.IdCustomer);

            if (customer == null)
            {
                _notifier.Handle("Customer não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Customer = null;

            _unitOfWork.RepositoryFactory.SaleRepository.Update(entity);

            await _unitOfWork.RepositoryFactory.SaleRepository.Commit();
            await _saleProductService.Update(entity.SaleProduct);
        }
    }
}
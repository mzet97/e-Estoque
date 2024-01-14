using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class SaleProductService : BaseService, ISaleProductService
    {
        public SaleProductService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public async Task Create(SaleProduct entity)
        {
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

            var sale = await _unitOfWork
               .RepositoryFactory
               .SaleRepository
               .GetById(entity.IdSale);

            if (sale == null)
            {
                _notifier.Handle("Sale não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Product = null;

            await _unitOfWork
                .RepositoryFactory
                .SaleProductRepository
                .Create(entity);

            await _unitOfWork
                .RepositoryFactory
                .SaleProductRepository
                .Commit();
        }

        public async Task Create(IEnumerable<SaleProduct> entities)
        {
            foreach (var entity in entities)
            {
                await Create(entity);
            }
        }

        public async Task<IEnumerable<SaleProduct>> Find(Expression<Func<SaleProduct, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.SaleProductRepository.Find(predicate);
        }

        public async Task<IEnumerable<SaleProduct>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.SaleProductRepository.GetAll();
        }

        public async Task<SaleProduct> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.SaleProductRepository.GetById(id);
        }

        public async Task Remove(Guid id, SaleProduct entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("SaleProduc invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("SaleProduc não encontrada", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.SaleProductRepository.Remove(id);

            await _unitOfWork.RepositoryFactory.SaleProductRepository.Commit();
        }

        public async Task Remove(IEnumerable<SaleProduct> entity)
        {
            foreach (var item in entity)
            {
                await Remove(item.Id, item);
            }
        }

        public async Task<IEnumerable<SaleProduct>> Search(Expression<Func<SaleProduct, bool>> predicate = null, Func<IQueryable<SaleProduct>, IOrderedQueryable<SaleProduct>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.SaleProductRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public Task Update(Guid id, SaleProduct entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(IEnumerable<SaleProduct> entity)
        {
            var temp = await _unitOfWork
                .RepositoryFactory
                .SaleProductRepository
                .Find(x => x.IdSale == entity.FirstOrDefault().IdSale);
            
            var olds = temp.ToList();

            if(olds.Count == 0)
            {
                await Create(entity);
                return;
            }

            var listAdd = new List<SaleProduct>();
            var listDelete = new List<SaleProduct>();

            foreach (var item in entity)
            {
                var old = olds.FirstOrDefault(x => x.IdProduct == item.IdProduct);

                if (old == null)
                {
                    listAdd.Add(item);
                }
                else
                {
                    listDelete.Add(old);
                }
            }

            await Create(listAdd);
            await Remove(listDelete);
        }
    }
}
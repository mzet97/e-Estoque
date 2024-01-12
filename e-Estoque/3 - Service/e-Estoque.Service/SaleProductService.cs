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

        public Task Create(SaleProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleProduct>> Find(Expression<Func<SaleProduct, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleProduct>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SaleProduct> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, SaleProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleProduct>> Search(Expression<Func<SaleProduct, bool>> predicate = null, Func<IQueryable<SaleProduct>, IOrderedQueryable<SaleProduct>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, SaleProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
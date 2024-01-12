using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class SaleService : BaseService, ISaleService
    {
        public SaleService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(Sale entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> Find(Expression<Func<Sale, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, Sale entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> Search(Expression<Func<Sale, bool>> predicate = null, Func<IQueryable<Sale>, IOrderedQueryable<Sale>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Sale entity)
        {
            throw new NotImplementedException();
        }
    }
}
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class CustomerAddressService : BaseService, ICustomerAddressService
    {
        public CustomerAddressService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(CustomerAddress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAddress>> Find(Expression<Func<CustomerAddress, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAddress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddress> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, CustomerAddress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAddress>> Search(Expression<Func<CustomerAddress, bool>> predicate = null, Func<IQueryable<CustomerAddress>, IOrderedQueryable<CustomerAddress>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, CustomerAddress entity)
        {
            throw new NotImplementedException();
        }
    }
}
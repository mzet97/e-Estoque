using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> Search(Expression<Func<Customer, bool>> predicate = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

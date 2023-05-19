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
    public class CustomerAdressService : BaseService, ICustomerAdressService
    {
        public CustomerAdressService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(CustomerAdress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAdress>> Find(Expression<Func<CustomerAdress, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAdress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAdress> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, CustomerAdress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerAdress>> Search(Expression<Func<CustomerAdress, bool>> predicate = null, Func<IQueryable<CustomerAdress>, IOrderedQueryable<CustomerAdress>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, CustomerAdress entity)
        {
            throw new NotImplementedException();
        }
    }
}

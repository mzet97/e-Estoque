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
    public class InventoryService : BaseService, IInventoryService
    {
        public InventoryService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inventory>> Find(Expression<Func<Inventory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inventory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inventory>> Search(Expression<Func<Inventory, bool>> predicate = null, Func<IQueryable<Inventory>, IOrderedQueryable<Inventory>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Inventory entity)
        {
            throw new NotImplementedException();
        }
    }
}

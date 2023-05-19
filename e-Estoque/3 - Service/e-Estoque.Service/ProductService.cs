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
    public class ProductService : BaseService, IProductService
    {
        public ProductService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Search(Expression<Func<Product, bool>> predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

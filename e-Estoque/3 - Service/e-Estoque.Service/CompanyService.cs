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
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> Find(Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> Search(Expression<Func<Company, bool>> predicate = null, Func<IQueryable<Company>, IOrderedQueryable<Company>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Company entity)
        {
            throw new NotImplementedException();
        }
    }
}

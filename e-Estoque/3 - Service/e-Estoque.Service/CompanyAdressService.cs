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
    public class CompanyAdressService : BaseService, ICompanyAdressService
    {
        public CompanyAdressService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(CompanyAdress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAdress>> Find(Expression<Func<CompanyAdress, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAdress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyAdress> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, CompanyAdress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAdress>> Search(Expression<Func<CompanyAdress, bool>> predicate = null, Func<IQueryable<CompanyAdress>, IOrderedQueryable<CompanyAdress>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, CompanyAdress entity)
        {
            throw new NotImplementedException();
        }
    }
}

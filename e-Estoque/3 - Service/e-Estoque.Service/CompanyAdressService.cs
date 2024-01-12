using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class CompanyAddressService : BaseService, ICompanyAddressService
    {
        public CompanyAddressService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public Task Create(CompanyAddress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAddress>> Find(Expression<Func<CompanyAddress, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAddress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyAddress> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id, CompanyAddress entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAddress>> Search(Expression<Func<CompanyAddress, bool>> predicate = null, Func<IQueryable<CompanyAddress>, IOrderedQueryable<CompanyAddress>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, CompanyAddress entity)
        {
            throw new NotImplementedException();
        }
    }
}
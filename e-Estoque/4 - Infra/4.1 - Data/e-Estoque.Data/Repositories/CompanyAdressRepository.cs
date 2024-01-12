using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Data.Context;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Repositories;

namespace e_Estoque.Data.Repositories
{
    public class CompanyAddressRepository : Repository<CompanyAddress>, ICompanyAddressRepository
    {
        public CompanyAddressRepository(
            EstoqueDbContext db,
            INotifier notifier) : base(db, notifier)
        {
        }
    }
}
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Data.Context;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(
            EstoqueDbContext db, 
            INotifier notifier) : base(db, notifier)
        {
        }

        public override async Task<IEnumerable<Customer>> GetAll()
        {
            return await DbSet
              .AsNoTracking()
              .Include("CustomerAddress")
              .ToListAsync();
        }

        public override async Task<Customer> GetById(Guid id)
        {
            return await DbSet
               .AsNoTracking()
               .Include("CustomerAddress")
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
        }

        public override async Task Remove(Guid id)
        {
            var entity = await GetById(id);
            entity.UpdatedAt = DateTime.Now;
            entity.DeletedAt = DateTime.Now;
            DbSet.Update(entity);
        }
    }
}

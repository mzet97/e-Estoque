using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Data.Context;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace e_Estoque.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(
            EstoqueDbContext db,
            INotifier notifier) : base(db, notifier)
        {
        }

        public override async Task<IEnumerable<Product>> GetAll()
        {
            return await DbSet
                .Include("Category")
                .Include("Company")
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Product> GetById(Guid id)
        {
            return await DbSet
                .Include("Category")
                .Include("Company")
                .AsNoTracking()
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
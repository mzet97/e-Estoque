using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Data.Context;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace e_Estoque.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly EstoqueDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly INotifier _notifier;
        protected int Count;

        public Repository(
            EstoqueDbContext db,
            INotifier notifier)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
            Count = DbSet.AsQueryable().Count();
            _notifier = notifier;
        }

        public virtual async Task Create(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task<bool> Commit()
        {
            var result = await Db.SaveChangesAsync();
            return await Task.FromResult(result > 0);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(Guid id)
        {
            var entity = await GetById(id);
            entity.UpdatedAt = DateTime.Now;
            entity.DeletedAt = DateTime.Now;
            DbSet.Update(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> Search(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? pageSize = null,
            int? pageIndex = null)
        {
            var query = DbSet.AsQueryable();
            Count = query.Count();
            int pages = 0;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (pageSize != null && pageSize.HasValue && pageSize > 0)
            {
                pages = Count / pageSize.Value;

                if (pageIndex != null && pageIndex.HasValue && pageIndex.Value > 0)
                {
                    if (pageIndex.Value > pages)
                    {
                        query = query.OrderBy(x => x.Id).Skip(pageSize.Value * pages).Take(pageSize.Value);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Id).Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value);
                    }
                }
                else
                {
                    query = query.OrderBy(x => x.Id).Skip(pageSize.Value);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            DbSet.Update(entity);
        }
    }
}
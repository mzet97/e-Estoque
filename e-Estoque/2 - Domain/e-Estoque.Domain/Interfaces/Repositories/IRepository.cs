using e_Estoque.Domain.Entities;
using System.Linq.Expressions;

namespace e_Estoque.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Create(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);

        Task Remove(Guid id);

        Task<IEnumerable<TEntity>> Search(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? pageSize = null,
            int? pageIndex = null);

        Task<bool> Commit();
    }
}
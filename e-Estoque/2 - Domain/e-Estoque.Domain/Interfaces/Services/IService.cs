using e_Estoque.Domain.Entities;
using System.Linq.Expressions;

namespace e_Estoque.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : Entity
    {
        Task Create(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task Update(Guid id, TEntity entity);

        Task Remove(Guid id, TEntity entity);

        Task<IEnumerable<TEntity>> Search(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? pageSize = null,
            int? pageIndex = null);
    }
}
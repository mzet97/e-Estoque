using e_Estoque.Data.Context;
using e_Estoque.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EstoqueDbContext _dbContext;
        public IRepositoryFactory RepositoryFactory { get; }

        private bool disposed = false;

        public UnitOfWork(EstoqueDbContext dbContext, IRepositoryFactory repositoryFactory)
        {
            _dbContext = dbContext;
            RepositoryFactory = repositoryFactory;
        }

        public async Task<bool> Commit()
        {
            var result = await _dbContext.SaveChangesAsync();
            return await Task.FromResult(result > 0);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

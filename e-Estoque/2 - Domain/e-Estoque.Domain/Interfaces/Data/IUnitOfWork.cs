using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        void Dispose();

        IRepositoryFactory RepositoryFactory { get; }
    }
}

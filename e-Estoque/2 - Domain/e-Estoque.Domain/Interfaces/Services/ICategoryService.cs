using e_Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task Create(Category entity);
        Task<Category> GetById(Guid id);
        Task<IEnumerable<Category>> GetAll();
        Task Edit(Guid id, Category entity);
        Task Delete(Guid id, Category entity);
    }
}

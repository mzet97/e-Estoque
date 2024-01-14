using e_Estoque.Domain.Entities;

namespace e_Estoque.Domain.Interfaces.Services
{
    public interface ISaleProductService : IService<SaleProduct>
    {
        Task Create(IEnumerable<SaleProduct> entities);
        Task Update(IEnumerable<SaleProduct> entity);
        Task Remove(IEnumerable<SaleProduct> entity);
    }
}
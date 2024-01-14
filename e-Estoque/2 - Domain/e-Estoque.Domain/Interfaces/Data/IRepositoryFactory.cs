using e_Estoque.Domain.Interfaces.Repositories;

namespace e_Estoque.Domain.Interfaces.Data
{
    public interface IRepositoryFactory
    {
        ICategoryRepository CategoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ISaleProductRepository SaleProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        ITaxRepository TaxRepository { get; }
    }
}
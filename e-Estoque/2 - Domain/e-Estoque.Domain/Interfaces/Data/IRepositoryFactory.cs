using e_Estoque.Domain.Interfaces.Repositories;

namespace e_Estoque.Domain.Interfaces.Data
{
    public interface IRepositoryFactory
    {
        ICategoryRepository CategoryRepository { get; }
        ICompanyAddressRepository CompanyAddressRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ISaleProductRepository SaleProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        ITaxRepository TaxRepository { get; }
    }
}
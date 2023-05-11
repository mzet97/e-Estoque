using e_Estoque.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Interfaces.Data
{
    public interface IRepositoryFactory
    {
        ICategoryRepository CategoryRepository { get; }
        ICompanyAdressRepository CompanyAdressRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICustomerAdressRepository CustomerAdressRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ISaleProductRepository SaleProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        ITaxRepository TaxRepository { get; }
    }
}

using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Data.Context;
using e_Estoque.Data.Repositories;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Repositories;

namespace e_Estoque.Data
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly EstoqueDbContext _dbContext;
        private readonly INotifier _notifier;

        public RepositoryFactory(
            EstoqueDbContext dbContext,
            INotifier notifier
            )
        {
            _dbContext = dbContext;
            _notifier = notifier;
        }

        private ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository
        { get => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_dbContext, _notifier)); }

        private ICompanyRepository _companyRepository;

        public ICompanyRepository CompanyRepository
        { get => _companyRepository ?? (_companyRepository = new CompanyRepository(_dbContext, _notifier)); }

        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        { get => _customerRepository ?? (_customerRepository = new CustomerRepository(_dbContext, _notifier)); }


        private IInventoryRepository _inventoryRepository;

        public IInventoryRepository InventoryRepository
        { get => _inventoryRepository ?? (_inventoryRepository = new InventoryRepository(_dbContext, _notifier)); }

        private IProductRepository _productRepository;

        public IProductRepository ProductRepository
        { get => _productRepository ?? (_productRepository = new ProductRepository(_dbContext, _notifier)); }

        private ISaleProductRepository _saleProductRepository;

        public ISaleProductRepository SaleProductRepository
        { get => _saleProductRepository ?? (_saleProductRepository = new SaleProductRepository(_dbContext, _notifier)); }

        private ISaleRepository _saleRepository;

        public ISaleRepository SaleRepository
        { get => _saleRepository ?? (_saleRepository = new SaleRepository(_dbContext, _notifier)); }

        private ITaxRepository _taxRepository;

        public ITaxRepository TaxRepository
        { get => _taxRepository ?? (_taxRepository = new TaxRepository(_dbContext, _notifier)); }
    }
}
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Data;
using e_Estoque.Data.Context;
using e_Estoque.Data.Repositories;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Repositories;
using e_Estoque.Domain.Interfaces.Services;
using e_Estoque.Infra.Mail;
using e_Estoque.Service;

namespace e_Estoque.App.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EstoqueDbContext>();
            services.AddScoped<HttpContextAccessor>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IEmailService, EmailService>();

            #region Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICompanyAdressRepository, CompanyAdressRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerAdressRepository, CustomerAdressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ICustomerAdressRepository, CustomerAdressRepository>();
            services.AddScoped<ISaleProductRepository, SaleProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();


            #endregion

            #region Service
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyAdressService, CompanyAdressService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICustomerAdressService, CustomerAdressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ICustomerAdressService, CustomerAdressService>();
            services.AddScoped<ISaleProductService, SaleProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ITaxService, TaxService>();


            #endregion

            return services;
        }
    }
}

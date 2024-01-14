using AutoMapper;
using e_Estoque.App.ViewModels.Category;
using e_Estoque.App.ViewModels.Company;
using e_Estoque.App.ViewModels.Customer;
using e_Estoque.App.ViewModels.Inventory;
using e_Estoque.App.ViewModels.Product;
using e_Estoque.App.ViewModels.Tax;
using e_Estoque.Domain.Entities;

namespace e_Estoque.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryCreatedViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<Tax, TaxCreatedViewModel>().ReverseMap();
            CreateMap<Tax, TaxViewModel>().ReverseMap();

            CreateMap<CompanyAddress, CompanyAddressCreatedViewModel>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressViewModel>().ReverseMap();

            CreateMap<Company, CompanyCreatedViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();

            CreateMap<CustomerAddress, CustomerAddressCreatedViewModel>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressViewModel>().ReverseMap();

            CreateMap<Customer, CustomerCreatedViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

            CreateMap<Product, ProductCreatedViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();

            CreateMap<Inventory, InventoryCreatedViewModel>().ReverseMap();
            CreateMap<Inventory, InventoryViewModel>().ReverseMap();
        }
    }
}
using AutoMapper;
using e_Estoque.App.ViewModels.Category;
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
        }
    }
}

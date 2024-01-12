using e_Estoque.App.ViewModels.Category;
using e_Estoque.App.ViewModels.Company;

namespace e_Estoque.App.ViewModels.Product
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; } = string.Empty;

        public Guid IdCategory { get; set; }
        public CategoryViewModel Category { get; set; } = null!;

        public Guid IdCompany { get; set; }
        public CompanyViewModel Company { get; set; } = null!;
    }
}
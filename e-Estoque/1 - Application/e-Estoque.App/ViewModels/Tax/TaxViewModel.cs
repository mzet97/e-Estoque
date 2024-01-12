using e_Estoque.App.ViewModels.Category;

namespace e_Estoque.App.ViewModels.Tax
{
    public class TaxViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Percentage { get; set; }

        public Guid IdCategory { get; set; }
        public CategoryViewModel Category { get; set; } = null!;
    }
}
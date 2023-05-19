using e_Estoque.App.ViewModels.Category;

namespace e_Estoque.App.ViewModels.Tax
{
    public class TaxViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Percentage { get; set; }

        public Guid IdCategory { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}

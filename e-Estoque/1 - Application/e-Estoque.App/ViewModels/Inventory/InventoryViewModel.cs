using e_Estoque.App.ViewModels.Product;

namespace e_Estoque.App.ViewModels.Inventory
{
    public class InventoryViewModel : BaseViewModel
    {
        public int Quantity { get; set; }
        public DateTime DateOrder { get; set; }
        
        public Guid IdProduct { get; set; }
        public ProductViewModel Product { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Inventory
{
    public class InventoryCreatedViewModel
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateOrder { get; set; }

        [Required]
        public Guid IdProduct { get; set; }
    }
}

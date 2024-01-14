using e_Estoque.App.ViewModels.Customer;
using e_Estoque.App.ViewModels.Product;
using e_Estoque.Domain.Entities.Enums;

namespace e_Estoque.App.ViewModels.Sale
{
    public class SaleViewModel : BaseViewModel
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTax { get; set; }

        public SaleType SaleType { get; set; }
        public PaymentType PaymentType { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        public Guid IdCustomer { get; set; }
        public CustomerViewModel Customer { get; set; } = null!;

        public IEnumerable<ProductViewModel> Products { get; set; } = null!;
    }
}

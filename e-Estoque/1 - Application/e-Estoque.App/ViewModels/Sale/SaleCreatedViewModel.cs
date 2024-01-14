using e_Estoque.Domain.Entities.Enums;

namespace e_Estoque.App.ViewModels.Sale
{
    public class SaleCreatedViewModel
    {
        public int Quantity { get; set; }
        public SaleType SaleType { get; set; }
        public PaymentType PaymentType { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Guid IdCustomer { get; set; }

        public IEnumerable<Guid> Products { get; set; } = null!;
    }
}

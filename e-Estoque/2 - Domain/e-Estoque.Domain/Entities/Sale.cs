using e_Estoque.Domain.Entities.Enums;

namespace e_Estoque.Domain.Entities
{
    public class Sale : Entity
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTax { get; set; }

        public SaleType SaleType { get; set; }
        public PaymentType PaymentType { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        #region EFCRelations
        public Guid IdCustomer { get; set; }
        public Customer Customer { get; set; }

        public virtual IEnumerable<SaleProduct> SaleProduct { get; set; }

        #endregion
    }
}

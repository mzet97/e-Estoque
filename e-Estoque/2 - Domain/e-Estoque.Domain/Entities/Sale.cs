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
        public Customer Customer { get; set; } = null!;

        public virtual IEnumerable<SaleProduct> SaleProduct { get; set; } = null!;

        #endregion EFCRelations

        public Sale()
        {
            
        }

        public Sale(
            int quantity,
            decimal totalPrice,
            decimal totalTax,
            SaleType saleType,
            PaymentType paymentType,
            DateTime? deliveryDate,
            DateTime saleDate,
            DateTime? paymentDate,
            Guid idCustomer,
            List<SaleProduct> saleProduct)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
            TotalTax = totalTax;
            SaleType = saleType;
            PaymentType = paymentType;
            DeliveryDate = deliveryDate;
            SaleDate = saleDate;
            PaymentDate = paymentDate;
            IdCustomer = idCustomer;
            SaleProduct = saleProduct;
        }

        public Sale(
           Guid id,
           int quantity,
           decimal totalPrice,
           decimal totalTax,
           SaleType saleType,
           PaymentType paymentType,
           DateTime? deliveryDate,
           DateTime saleDate,
           DateTime? paymentDate,
            DateTime createdAt,
            DateTime? updatedAt,
            DateTime? deletedAt,
           Guid idCustomer,
           List<SaleProduct> saleProduct)
        {
            Id = id;
            Quantity = quantity;
            TotalPrice = totalPrice;
            TotalTax = totalTax;
            SaleType = saleType;
            PaymentType = paymentType;
            DeliveryDate = deliveryDate;
            SaleDate = saleDate;
            PaymentDate = paymentDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
            IdCustomer = idCustomer;
            SaleProduct = saleProduct;
        }
    }
}
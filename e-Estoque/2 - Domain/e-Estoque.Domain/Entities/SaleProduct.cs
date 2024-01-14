namespace e_Estoque.Domain.Entities
{
    public class SaleProduct : Entity
    {
        public Guid IdProduct { get; set; }
        public virtual Product Product { get; set; } = null!;

        public Guid IdSale { get; set; }
        public virtual Sale Sale { get; set; } = null!;

        public SaleProduct()
        {
            
        }

        public SaleProduct(Guid idProduct)
        {
            IdProduct = idProduct;
        }

        public SaleProduct(Guid idProduct, Guid idSale)
        {
            IdProduct = idProduct;
            IdSale = idSale;
        }

        public SaleProduct(Guid id, Guid idProduct, Guid idSale)
        {
            Id = id;
            IdProduct = idProduct;
            IdSale = idSale;
        }

        public SaleProduct(Guid idProduct, Product product, Guid idSale, Sale sale)
        {
            IdProduct = idProduct;
            Product = product;
            IdSale = idSale;
            Sale = sale;
        }
    }
}
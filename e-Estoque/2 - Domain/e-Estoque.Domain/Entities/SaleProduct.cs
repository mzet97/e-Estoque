namespace e_Estoque.Domain.Entities
{
    public class SaleProduct : Entity
    {
        public Guid IdProduct { get; set; }
        public virtual Product Product { get; set; } = null!;

        public Guid IdSale { get; set; }
        public virtual Sale Sale { get; set; } = null!;
    }
}
namespace e_Estoque.Domain.Entities
{
    public class Inventory : Entity
    {
        public int Quantity { get; set; }
        public DateTime DateOrder { get; set; }

        #region EFCRelations

        public Guid IdProduct { get; set; }
        public virtual Product Product { get; set; } = null!;

        #endregion EFCRelations
    }
}
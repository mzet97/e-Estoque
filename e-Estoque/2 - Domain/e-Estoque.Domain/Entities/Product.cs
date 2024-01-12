namespace e_Estoque.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; } = string.Empty;

        #region EFCRelations

        public Guid IdCategory { get; set; }
        public virtual Category Category { get; set; } = null!;

        public Guid IdCompany { get; set; }
        public virtual Company Company { get; set; } = null!;

        #endregion EFCRelations
    }
}
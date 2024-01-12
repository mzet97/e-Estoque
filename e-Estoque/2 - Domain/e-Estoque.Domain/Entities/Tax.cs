namespace e_Estoque.Domain.Entities
{
    public class Tax : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Percentage { get; set; }

        #region EFCRelations

        public Guid IdCategory { get; set; }
        public virtual Category Category { get; set; } = null!;

        #endregion EFCRelations
    }
}
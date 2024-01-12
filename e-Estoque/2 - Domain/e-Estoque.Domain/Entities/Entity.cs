namespace e_Estoque.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
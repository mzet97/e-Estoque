namespace e_Estoque.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string DocId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid IdCustomerAddress { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; } = null!;
    }
}
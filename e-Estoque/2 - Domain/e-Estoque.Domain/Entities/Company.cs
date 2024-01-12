namespace e_Estoque.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string DocId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Guid IdCompanyAddress { get; set; }
        public virtual CompanyAddress CompanyAddress { get; set; } = null!;
    }
}
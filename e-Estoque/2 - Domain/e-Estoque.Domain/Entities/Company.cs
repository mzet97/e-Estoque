namespace e_Estoque.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string DocId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public Guid IdCompanyAdress { get; set; }
        public virtual CompanyAdress CompanyAdress { get; set; }
    }
}

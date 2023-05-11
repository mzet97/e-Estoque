namespace e_Estoque.Domain.Entities
{
    public class CompanyAdress : Adress
    {
        public Guid IdCompany { get; set; }
        public virtual Company Company { get; set; }
    }
}

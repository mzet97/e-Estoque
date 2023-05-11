namespace e_Estoque.Domain.Entities
{
    public class CustomerAdress : Adress
    {
        public Guid IdCustomer { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

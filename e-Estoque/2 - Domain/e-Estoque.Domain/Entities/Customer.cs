﻿namespace e_Estoque.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string DocId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public Guid IdCustomerAdress { get; set; }
        public virtual CustomerAdress CustomerAdress { get; set; }
    }
}

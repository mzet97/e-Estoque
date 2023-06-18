namespace e_Estoque.App.ViewModels.Customer
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string DocId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public Guid IdCustomerAdress { get; set; }
        public CustomerAdressViewModel CustomerAdress { get; set; }
    }
}

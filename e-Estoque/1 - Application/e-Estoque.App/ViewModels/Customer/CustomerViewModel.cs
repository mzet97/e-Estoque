namespace e_Estoque.App.ViewModels.Customer
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string DocId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Guid IdCustomerAddress { get; set; }
        public CustomerAddressViewModel CustomerAddress { get; set; } = null!;
    }
}
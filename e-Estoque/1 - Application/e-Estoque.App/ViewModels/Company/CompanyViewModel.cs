namespace e_Estoque.App.ViewModels.Company
{
    public class CompanyViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string DocId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public Guid IdCompanyAdress { get; set; }
        public CompanyAdressViewModel CompanyAdress { get; set; }
    }
}

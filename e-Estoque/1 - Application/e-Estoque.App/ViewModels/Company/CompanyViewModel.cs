namespace e_Estoque.App.ViewModels.Company
{
    public class CompanyViewModel : BaseViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string DocId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Guid IdCompanyAddress { get; set; }
        public CompanyAddressViewModel CompanyAddress { get; set; } = null!;
    }
}
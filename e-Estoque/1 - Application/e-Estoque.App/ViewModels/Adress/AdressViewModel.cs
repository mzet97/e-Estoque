namespace e_Estoque.App.ViewModels.Address
{
    public class AddressViewModel : BaseViewModel
    {
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
    }
}
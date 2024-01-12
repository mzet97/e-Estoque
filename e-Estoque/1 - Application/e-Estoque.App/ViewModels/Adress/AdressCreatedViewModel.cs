using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Address
{
    public class AddressCreatedViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        [MaxLength(5)]
        public string Number { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Complement { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Neighborhood { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string District { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string County { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Latitude { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Longitude { get; set; } = string.Empty;
    }
}
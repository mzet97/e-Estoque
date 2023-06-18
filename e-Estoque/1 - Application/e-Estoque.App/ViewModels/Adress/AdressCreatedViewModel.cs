using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Adress
{
    public class AdressCreatedViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Street { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(5)]
        public string Number { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Complement { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Neighborhood { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string District { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string City { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string County { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string ZipCode { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Latitude { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Longitude { get; set; }
    }
}

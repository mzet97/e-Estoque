using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Customer
{
    public class CustomerCreatedViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string DocId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public CustomerAdressCreatedViewModel CustomerAdress { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Customer
{
    public class CustomerCreatedViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string DocId { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        public CustomerAddressCreatedViewModel CustomerAddress { get; set; } = null!;
    }
}
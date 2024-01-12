using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Product
{
    public class ProductCreatedViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Length { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public Guid IdCategory { get; set; }

        [Required]
        public Guid IdCompany { get; set; }
    }
}
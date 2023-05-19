using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Tax
{
    public class TaxCreatedViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        public decimal Percentage { get; set; }

        [Required]
        public Guid IdCategory { get; set; }

    }
}

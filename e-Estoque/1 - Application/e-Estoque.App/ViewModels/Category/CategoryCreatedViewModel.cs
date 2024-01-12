using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Category
{
    public class CategoryCreatedViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        [MaxLength(250)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;
    }
}
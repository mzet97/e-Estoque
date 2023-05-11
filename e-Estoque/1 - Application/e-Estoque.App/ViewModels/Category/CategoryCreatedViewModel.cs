using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels.Category
{
    public class CategoryCreatedViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(5000)]
        public string Description { get; set; }

    }
}

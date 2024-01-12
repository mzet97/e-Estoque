using System.ComponentModel.DataAnnotations;

namespace e_Estoque.App.ViewModels
{
    public abstract class BaseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; }

        #region EFCRelations

        public Guid IdCategory { get; set; }
        public virtual Category Category { get; set; }

        public Guid IdCompany { get; set; }
        public virtual Company Company { get; set; }

        #endregion
    }
}

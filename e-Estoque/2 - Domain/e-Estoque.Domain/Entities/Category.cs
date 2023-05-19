using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public virtual IEnumerable<Tax> Taxs { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}

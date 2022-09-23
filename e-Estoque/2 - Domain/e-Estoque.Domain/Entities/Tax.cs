using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Entities
{
    public class Tax : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Percentage { get; set; }

        #region EFCRelations
        public Guid IdCategory { get; set; }
        public virtual Category Category { get; set; }

        #endregion
    }
}

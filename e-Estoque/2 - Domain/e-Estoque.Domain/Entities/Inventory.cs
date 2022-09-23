using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Entities
{
    public class Inventory : Entity
    {
        public int Quantity { get; set; }
        public DateTime DateOrder { get; set; }


        #region EFCRelations
        public Guid IdProduct { get; set; }
        public Product Product { get; set; }

        public Guid IdProvider { get; set; }
        public Provider Provider { get; set; }

        #endregion

        
    }
}

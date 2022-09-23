using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Trade { get; set; }

        public virtual IEnumerable<CompanyAdresss> CompanyAdresss { get; set; }
    }
}

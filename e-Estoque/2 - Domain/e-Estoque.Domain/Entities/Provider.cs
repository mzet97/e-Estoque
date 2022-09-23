﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Domain.Entities
{
    public class Provider : Company
    {
        public virtual IEnumerable<Inventory> Inventories { get; set; }
    }
}

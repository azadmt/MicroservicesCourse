using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Model
{
    public class Stock : EntityBase
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }

    }
}

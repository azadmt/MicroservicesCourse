using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DataContract
{
    public class UpdateStockQuantity
    {
        public long ProductId { get; set; }
        public int Quantity{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contract
{
    public class OrderPlacedEvent
    {
        public long OrderId { get; set; }
        public string Address { get; set; }
    }
}

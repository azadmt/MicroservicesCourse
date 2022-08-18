using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contract
{
    public class OrderPlacedEvent
    {
        public OrderPlacedEvent(long orderId, string address)
        {
            OrderId = orderId;
            Address = address;
        }
        public long OrderId { get; private set; }
        public string Address { get; private set; }
    }
}

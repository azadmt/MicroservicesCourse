using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contract
{
    public class OrderCreatedEvent
    {
        public OrderCreatedEvent(long orderId, Dictionary<long, int> orderItems)
        {
            OrderItems = orderItems;
            OrderId = orderId;
        }

        // TODO: Refactor to better data structure !!!
        public Dictionary<long, int> OrderItems { get; private set; }
        public long OrderId { get; private set; }

    }

    public class StockAdjusmentConfirmedEvent
    {
        public StockAdjusmentConfirmedEvent(long orderId)
        {
            OrderId = orderId;
        }
        public long OrderId { get; private set; }

    }

    public class StockAdjusmentRejectedEvent
    {
        public StockAdjusmentRejectedEvent(long orderId)
        {
            OrderId = orderId;
        }
        public long OrderId { get; private set; }

    }
}

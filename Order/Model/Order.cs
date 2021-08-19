using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Model
{
    public class Order : EntityBase
    {
        public long CustomerId { get; set; }
        public DateTime CreateDate { get; set; }

        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void AddOrderItem(OrderItem item)
        {
            item.OrderId = Id;
            OrderItems.Add(item);
        }
    }
}

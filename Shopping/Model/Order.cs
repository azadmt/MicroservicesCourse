using System;
using System.Collections.Generic;

namespace Shopping.Model
{
    public class Order : EntityBase
    {
        public long CustomerId { get; set; }
        public long CourierId { get; set; }

        public virtual Customer Customer { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public string Address{ get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void AddOrderItem(OrderItem item)
        {
            item.Order = this;
            OrderItems.Add(item);
        }
    }

    public class Courier : EntityBase
    {
        public bool IsAvailable { get; set; }
       
    }
}

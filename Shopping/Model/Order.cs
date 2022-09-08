using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Model
{
    public class Order : EntityBase
    {
        public long CustomerId { get; set; }


        public virtual Customer Customer { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void AddOrderItem(OrderItem item)
        {
            item.Order = this;
            OrderItems.Add(item);
        }
    }

    public class OutboxEvent
    {
        [Key]
        public Guid Id { get; set; } = new();
        public string Payload { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? SyncDate { get; set; } 
        public bool IsSynced { get; set; }
    }

}

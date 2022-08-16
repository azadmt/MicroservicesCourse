using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Model
{
    [Table("OrderItems", Schema = "Shopping")]

    public class OrderItem : EntityBase
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Unit { get; set; }

        public decimal Price { get; set; }
    }
}

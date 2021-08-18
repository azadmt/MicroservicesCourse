using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataContract
{
    public class OrderDto
    {
        public long CustomerId { get; set; }
        public DateTime CreateDate { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

    }

    public class OrderItemDto
    {
        public long ProductId { get; set; }

        public int Unit { get; set; }
    }
}

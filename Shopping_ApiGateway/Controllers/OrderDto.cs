using System;
using System.Collections.Generic;

namespace Shopping_ApiGateway.Controllers
{
    public class OrderDto
    {
        public long CustomerId { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

    }
}

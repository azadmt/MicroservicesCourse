using OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Contract
{
    public class OrderDto 
    {
        public long CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

 
    }
}

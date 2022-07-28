using OrderManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Model
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

      public  static Order CreateOrder(OrderDto orderDto)
        {
            var ordr= new Order { CreateDate = DateTime.Now, CustomerId = orderDto.CustomerId, Status = OrderStatus.Submitted };

            foreach (var orerItemDto in orderDto.OrderItems)
            {
                //
                ordr.AddOrderItem(new OrderItem
                {
                    OrderId = orerItemDto.OrderId,
                    Price = orerItemDto.Price,
                    ProductId = orerItemDto.ProductId,
                    Unit= orerItemDto.Unit
                });
            }

            return ordr;

        }
    }
}

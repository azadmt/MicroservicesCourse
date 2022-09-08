using Contract;
using MassTransit;
using Newtonsoft.Json;
using Shopping.DataContract;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Shopping.Service
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingDbContext shoppingDbContext;
        private readonly IBusControl busControl;

        public OrderService(ShoppingDbContext shoppingDbContext, IBusControl busControl)
        {
            this.shoppingDbContext = shoppingDbContext;
            this.busControl = busControl;
        }

        public void ApproveOrder(long ordrId)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(OrderDto orderDto)
        {
            var productsId = orderDto.OrderItems.Select(p => p.ProductId).ToList();
            var products = shoppingDbContext.Products.Where(p => productsId.Contains(p.Id)).ToList();
            var order = new Order { CreateDate = DateTime.Now, CustomerId = orderDto.CustomerId, Status = OrderStatus.ApprovalPending };
            foreach (var item in orderDto.OrderItems)
            {
                var product = products.First(p => p.Id == item.ProductId);
                var orderItem = new OrderItem { ProductId = item.ProductId, Unit = item.Unit, Price = item.Unit * product.Price };
                order.AddOrderItem(orderItem);
            }
            shoppingDbContext.Orders.Add(order);
            // Outbox Pattern
            shoppingDbContext.OutboxEvents.Add(new OutboxEvent
            {
                Payload = JsonConvert.SerializeObject(new OrderCreatedEvent(order.Id, order.OrderItems.ToDictionary(p => p.ProductId, p => p.Unit))),
                IsSynced = false
            });
            shoppingDbContext.SaveChanges();
        }

        public void RejectOrder(long ordrId)
        {
            throw new NotImplementedException();
        }
    }

}



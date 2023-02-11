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
        private readonly IInventoryService inventoryService;
        private readonly IDeliveryService deliveryService;

        public OrderService(
            ShoppingDbContext shoppingDbContext,
            IInventoryService inventoryService, 
            IDeliveryService deliveryService)
        {
            this.inventoryService = inventoryService;
            this.shoppingDbContext = shoppingDbContext;
            this.deliveryService = deliveryService;
        }
        public async Task CreateOrder(OrderDto orderDto)
        {
            using var trx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
            var productsId = orderDto.OrderItems.Select(p => p.ProductId).ToList();
            var products = shoppingDbContext.Products.Where(p => productsId.Contains(p.Id)).ToList();
            var stocks = shoppingDbContext.Stocks.Where(p => productsId.Contains(p.ProductId)).ToList();
            var order = new Order { CreateDate = DateTime.Now, CustomerId = orderDto.CustomerId };
            foreach (var item in orderDto.OrderItems)
            {
                var product = products.First(p => p.Id == item.ProductId);
                var orderItem = new OrderItem { ProductId = item.ProductId, Unit = item.Unit, Price = item.Unit * product.Price };
                await inventoryService.AdjustStockQuantity(item.ProductId, item.Unit);
                order.AddOrderItem(orderItem);
            }
                shoppingDbContext.Orders.Add(order);
                shoppingDbContext.SaveChanges();
                //use from delivery service
              await  deliveryService.ScheduleDelivery(order.Id, orderDto.Address);

        }
    }

}



using Shopping.DataContract;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Service
{
    public class OrderService:IOrderService
    {
        private readonly ShoppingDbContext shoppingDbContext;

        public OrderService(ShoppingDbContext shoppingDbContext)
        {
            this.shoppingDbContext = shoppingDbContext;
        }
        public void CreateOrder(OrderDto orderDto)
        {
            var productsId = orderDto.OrderItems.Select(p => p.ProductId).ToList();
            var products = shoppingDbContext.Products.Where(p => productsId.Contains(p.Id)).ToList();
            var stocks = shoppingDbContext.Stocks.Where(p => productsId.Contains(p.ProductId)).ToList();
            var courier= shoppingDbContext.Couriers.Where(p => p.IsAvailable).FirstOrDefault();
            var order = new Order { CreateDate = DateTime.Now, CustomerId = orderDto.CustomerId };
            foreach (var item in orderDto.OrderItems)
            {
                var product = products.First(p => p.Id == item.ProductId);
                var orderItem = new OrderItem { ProductId = item.ProductId, Unit = item.Unit, Price = item.Unit * product.Price };
                var stock = stocks.First(p => p.ProductId == item.ProductId);
                if (stock.Quantity < item.Unit)
                {
                    throw new Exception("Quantity is not enough!!!");
                }
                stock.Quantity -= item.Unit;
                order.CourierId = courier.Id;
                order.Address = orderDto.Address;
                order.AddOrderItem(orderItem);
            }

                    shoppingDbContext.Orders.Add(order);
                   // shoppingDbContext.Stocks.Update(stock);
                    shoppingDbContext.SaveChanges();
          
               
            }
        }

    }



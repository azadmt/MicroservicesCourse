using Shopping.Model;
using System;
using System.Linq;

namespace Shopping.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ShoppingDbContext shoppingDbContext;

        public DeliveryService(ShoppingDbContext shoppingDbContext)
        {
            this.shoppingDbContext = shoppingDbContext;
        }
        public void Pickup(long id)
        {
            var delivery = shoppingDbContext.Deliveries.First(p => p.Id == id);
            var order = shoppingDbContext.Orders.First(p => p.Id == id);
            delivery.Status = DeliveryStatus.PickedUp;
            shoppingDbContext.Deliveries.Update(delivery);
            shoppingDbContext.SaveChanges();
        }

        public void ScheduleDelivery(long id)
        {
            var courier = shoppingDbContext.Couriers.First(p => p.IsAvailable);
            var delivery = shoppingDbContext.Deliveries.First(p => p.Id==id);
            var order = shoppingDbContext.Orders.First(p => p.Id == id);
            delivery.CourierId = courier.Id;
            delivery.Status = DeliveryStatus.Assigned;
            order.Status = OrderStatus.StockConfirmed;
            shoppingDbContext.Deliveries.Update(delivery);
            shoppingDbContext.Orders.Update(order);
            shoppingDbContext.SaveChanges();

        }
    }

}



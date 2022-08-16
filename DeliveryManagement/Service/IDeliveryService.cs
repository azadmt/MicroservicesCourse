using DeliveryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManagement.Service
{
    public interface IDeliveryService
    {
        void ScheduleDelivery(long orderId, string address);
        void Pickup(long id);
    }

    public class DeliveryService : IDeliveryService
    {
        private readonly DeliveryManagementDbContext dbContext;

        public DeliveryService(DeliveryManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Pickup(long id)
        {
            var delivery = dbContext.Deliveries.First(p => p.Id == id);
            delivery.Status = DeliveryStatus.PickedUp;
            dbContext.Deliveries.Update(delivery);
            dbContext.SaveChanges();
        }

        public void ScheduleDelivery(long orderId, string address)
        {
            var courier = dbContext.Couriers.First(p => p.IsAvailable);
            var delivery = new Delivery();
            delivery.OrderId = orderId;
            delivery.CourierId = courier.Id;
            delivery.Address = address;
            delivery.Status = DeliveryStatus.Assigned;
            dbContext.Deliveries.Add(delivery);
            dbContext.SaveChanges();

        }
    }

}

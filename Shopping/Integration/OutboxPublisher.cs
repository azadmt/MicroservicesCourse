using CronQuery.Mvc.Jobs;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Integration
{
    public class OutboxPublisher : IJob
    {
        private readonly ShoppingDbContext shoppingDbContext;
        private readonly IBusControl busControl;

        public OutboxPublisher(ShoppingDbContext shoppingDbContext, IBusControl busControl)
        {
            this.shoppingDbContext = shoppingDbContext;
            this.busControl = busControl;
        }
        public async Task RunAsync()
        {
            var notsyncedEvents = shoppingDbContext.OutboxEvents.Where(p => p.IsSynced == false).ToList();
            foreach (var item in notsyncedEvents)
            {
                await busControl.Publish(JsonConvert.DeserializeObject(item.Payload));
                item.IsSynced = true;
                item.SyncDate = DateTime.Now;
                shoppingDbContext.OutboxEvents.Update(item);
                await shoppingDbContext.SaveChangesAsync();
            }
        }
    }
}

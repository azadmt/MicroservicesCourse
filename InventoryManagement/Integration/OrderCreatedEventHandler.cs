using Contract;
using InventoryManagement.Service;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Integration
{
    public class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        private readonly IStockService stockService;

        public OrderCreatedEventHandler(IStockService stockService)
        {
            this.stockService = stockService;
        }
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            foreach (var item in context.Message.OrderItems)
            {
                try
                {
                    await stockService.UpdateStock(new DataContract.UpdateStockQuantity { ProductId = item.Key, Quantity = item.Value });
                }
                catch (Exception)
                {
                    await context.Publish(new StockAdjusmentRejectedEvent(context.Message.OrderId));
                    throw;
                }
            }
            await context.Publish(new StockAdjusmentConfirmedEvent(context.Message.OrderId));
        }

    }
}

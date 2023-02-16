using Contract;
using MassTransit;
using Shopping.Service;
using System;
using System.Threading.Tasks;

namespace Shopping.Integration
{
    public class StockAdjusmentRejectedEventHandler : IConsumer<StockAdjusmentRejectedEvent>
    {
        private readonly IOrderService orderService;

        public StockAdjusmentRejectedEventHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public async Task Consume(ConsumeContext<StockAdjusmentRejectedEvent> context)
        {
            //TODO
        }
    }
}

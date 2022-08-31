using Contract;
using MassTransit;
using Shopping.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Integration
{
    public class StockAdjusmentConfirmedEventHandler : IConsumer<StockAdjusmentConfirmedEvent>
    {
        private readonly IOrderService orderService;

        public StockAdjusmentConfirmedEventHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public Task Consume(ConsumeContext<StockAdjusmentConfirmedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}

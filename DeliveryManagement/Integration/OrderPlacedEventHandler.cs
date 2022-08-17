using Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManagement.Integration
{
    public class OrderPlacedEventHandler : IConsumer<OrderPlacedEvent>
    {
        public Task Consume(ConsumeContext<OrderPlacedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}

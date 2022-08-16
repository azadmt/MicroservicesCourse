using DeliveryManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {        
        private readonly IDeliveryService deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            
            this.deliveryService = deliveryService;
        }

        [HttpPost]
        public IActionResult ScheduleDelivery(ScheduleDeliveryDto scheduleDeliveryDto)
        {
            deliveryService.ScheduleDelivery(scheduleDeliveryDto.OrderId, scheduleDeliveryDto.Address);
            return Ok();
        }
    }
}

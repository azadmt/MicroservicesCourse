using Microsoft.AspNetCore.Mvc;
using Shopping.DataContract;
using Shopping.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IDeliveryService deliveryService;

        public OrderController(IOrderService orderService,IDeliveryService deliveryService)
        {
            this.orderService = orderService;
            this.deliveryService = deliveryService;
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            orderService.CreateOrder(orderDto);
            return Ok();
        }

        [HttpPost("DeliveryAssigne")]
        public IActionResult CreateOrder(long orderId)
        {
            deliveryService.ScheduleDelivery(orderId);
            return Ok();
        }
    }
}

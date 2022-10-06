using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_ApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;        

        public OrderController(RestClient client):base(client)
        {
          
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            var req = new RestRequest(new Uri($"{GetApiAddress()}"), Method.Post);
        
            req.AddJsonBody(orderDto);
            RestClient.Post(req);
            return Ok();
        }

        protected string GetApiAddress()
        {
            var address = GetServiceEndponit("Shopping");
            return $"{address}/Order";
        }
    }
}

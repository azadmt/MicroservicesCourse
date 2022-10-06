﻿using Microsoft.AspNetCore.Mvc;
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
       private readonly RestClient client;

        public OrderController(RestClient client)
        {
            this.client = client;
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            var req = new RestRequest(new Uri("http://localhost:31762/Order"), Method.Post);
            req.AddJsonBody<OrderDto>(orderDto);
            client.Post(req);
            return Ok();
        }

    }
}

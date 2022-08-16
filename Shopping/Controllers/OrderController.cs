﻿using Microsoft.AspNetCore.Mvc;
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

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //orderService.CreateOrder(orderDto);
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            orderService.CreateOrder(orderDto);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Controllers
{
    public class OrderController : Controller
    {
        //https://www.c-sharpcorner.com/article/distributed-transactions-with-webapi-across-application-domains/
        public IActionResult Index()
        {
            return View();
        }
    }
}

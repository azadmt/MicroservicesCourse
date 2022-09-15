using Microsoft.AspNetCore.Mvc;

namespace Shopping_ApiGateway.Controllers
{
    public class DeliveryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

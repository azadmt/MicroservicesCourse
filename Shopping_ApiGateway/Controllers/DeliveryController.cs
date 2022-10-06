using Microsoft.AspNetCore.Mvc;

namespace Shopping_ApiGateway.Controllers
{
    public class DeliveryController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

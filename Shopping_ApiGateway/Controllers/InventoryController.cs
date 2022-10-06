using Microsoft.AspNetCore.Mvc;

namespace Shopping_ApiGateway.Controllers
{
    public class InventoryController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
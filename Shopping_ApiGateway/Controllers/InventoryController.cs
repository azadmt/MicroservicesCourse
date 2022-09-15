using Microsoft.AspNetCore.Mvc;

namespace Shopping_ApiGateway.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

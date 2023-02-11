using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Shopping_ApiGateway.Controllers
{
    public class InventoryController : ControllerBase
    {
        public InventoryController(RestClient restClient) : base(restClient)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
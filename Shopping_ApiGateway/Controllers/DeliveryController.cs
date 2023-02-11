using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Shopping_ApiGateway.Controllers
{
    public class DeliveryController : ControllerBase
    {
        public DeliveryController(RestClient restClient):base(restClient)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

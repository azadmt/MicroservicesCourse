using Microsoft.AspNetCore.Mvc;

namespace Shopping_ApiGateway.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected string GetServiceAddress(string serviceName)
        {

            return "";
        }
    }
}
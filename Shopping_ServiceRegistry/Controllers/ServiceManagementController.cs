using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_ServiceRegistry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceManagementController : ControllerBase
    {
        static List<ServieModel> services = new List<ServieModel>();

        private readonly ILogger<ServiceManagementController> _logger;

        public ServiceManagementController(ILogger<ServiceManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string serviceName)
        {
            var service = services.Where(p => p.Name == serviceName).OrderBy(p => p.LastUpdate).FirstOrDefault();
            if (service is null)
                return NotFound(serviceName);

            service.LastUpdate = DateTime.Now;
            return Ok(new { ServiceAddress = service.BaseAddress });
        }

        [HttpPost]
        public IActionResult Register(RegisterServiceModel registerServiceModel)
        {
            if (!services.Any(
                p => p.Name == registerServiceModel.ServiceName
            && p.BaseAddress == registerServiceModel.BaseAddress))
            {
                services.Add(new ServieModel
                {
                    Name = registerServiceModel.ServiceName,
                    BaseAddress = registerServiceModel.BaseAddress
                });
            }
            return Ok();
        }
    }
}

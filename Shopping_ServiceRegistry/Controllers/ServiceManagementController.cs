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
            var service = services.Where(p => p.Name == serviceName).OrderBy(p => p.LastRequestTime).FirstOrDefault();
            if (service is null)
                return NotFound(serviceName);

            service.LastRequestTime = DateTime.Now;
            return Ok(new { ServiceAddress = service.BaseAddress });
        }

        [HttpPost]
        public IActionResult Register(string serviceName, string baseAddress)
        {
            services.Add(new ServieModel
            {
                Name = serviceName,
                BaseAddress = baseAddress
            });

            return Ok();
        }
    }
}

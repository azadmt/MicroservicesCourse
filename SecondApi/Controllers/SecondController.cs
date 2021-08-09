using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecondController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("second Api Response");
        }
    }
}

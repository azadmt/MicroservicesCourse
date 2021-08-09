using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("First Api Response");
        }
    }
}

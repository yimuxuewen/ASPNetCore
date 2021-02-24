using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroServiceInstance.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        private readonly IConfiguration _configuration;

        public HealthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<controller>
        [HttpGet("Index")]
        public IActionResult Get()
        {
            Console.WriteLine($"This is HealthController {_configuration["port"]} Invoke");
            return Ok();
        }
    }
}

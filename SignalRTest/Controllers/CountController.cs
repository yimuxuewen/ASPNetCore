using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Controllers
{
    [Route("api/count")]
    public class CountController : Controller
    {
        private readonly Microsoft.AspNetCore.SignalR.IHubContext<CountHub> _hubContext;

        public CountController(IHubContext<CountHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _hubContext.Clients.All.SendAsync("someFunc", new { random = "sdsfd" });
            return Accepted(1);
        }
    }
}

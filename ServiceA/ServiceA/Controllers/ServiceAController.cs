using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceA.Controllers
{
    [Route("[Controller]/api")]
    public class ServiceAController : ControllerBase
    {
        private readonly string service_b_url;
        private readonly IHttpClientFactory _clientFactory;
        public ServiceAController(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            service_b_url = configuration["ServiceBUrl"];
            _clientFactory = clientFactory;
        }
        [HttpGet("loop/services/data")]
        public async Task<IActionResult> LoopServicesData()
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetAsync(service_b_url);
            return Ok(result);
        }

        [HttpGet("innerloop")]
        public IActionResult InnerLoop()
        {
            return Ok("Service A Data");
        }
    }
}

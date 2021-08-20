using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ServiceAController> _logger;
        public ServiceAController(IConfiguration configuration, IHttpClientFactory clientFactory, ILogger<ServiceAController> logger)
        {
            _logger = logger;
            service_b_url = configuration["ServiceBUrl"];
            _clientFactory = clientFactory;
        }
        [HttpGet("loop/services/data")]
        public async Task<IActionResult> LoopServicesData()
        {
            _logger.LogInformation("Request entry LoopServicesData");
            var client = _clientFactory.CreateClient();
            var result = await client.GetAsync(service_b_url);
            _logger.LogInformation("Request end LoopServicesData");
            return Ok(await result.Content.ReadAsStringAsync());

        }

        [HttpGet("innerloop")]
        public IActionResult InnerLoop()
        {
            _logger.LogInformation("Request entry InnerLoop");
            _logger.LogInformation("Request end InnerLoop");
            return Ok("Service A Data");
        }
    }
}

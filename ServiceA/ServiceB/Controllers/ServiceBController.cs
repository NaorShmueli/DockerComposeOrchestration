using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceB.Controllers
{
    [Route("[Controller]/api")]
    public class ServiceBController : ControllerBase
    {
        private readonly string service_c_url;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ServiceBController> _logger;

        public ServiceBController(IConfiguration configuration, IHttpClientFactory clientFactory, ILogger<ServiceBController> logger)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            service_c_url = configuration["ServiceCUrl"];
        }
        [HttpGet("data")]
        public async Task<IActionResult> GetData()
        {
            _logger.LogInformation("Request entry Service******B******Controller GetData");
            var client = _clientFactory.CreateClient();
            var result = await client.GetAsync(service_c_url);
            _logger.LogInformation("Request end Service*******B*******Controller GetData");
            return Ok(await result.Content.ReadAsStringAsync());
        }
    }
}

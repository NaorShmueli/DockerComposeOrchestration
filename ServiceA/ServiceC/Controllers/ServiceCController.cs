using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceC.Controllers
{
    [Route("[Controller]/api")]
    public class ServiceCController : ControllerBase
    {
        private readonly string service_a_url;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ServiceCController> _logger;

        public ServiceCController(IConfiguration configuration, IHttpClientFactory clientFactory, ILogger<ServiceCController> logger)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            service_a_url = configuration["ServiceAUrl"];
        }
        [HttpGet("data")]
        public async Task<IActionResult> GetData()
        {
            _logger.LogInformation("Request entry Service******C******Controller GetData");
            var client = _clientFactory.CreateClient();
            var result = await client.GetAsync(service_a_url);
            _logger.LogInformation("Request end Service******C******Controller GetData");
            return Ok(await result.Content.ReadAsStringAsync());
        }
    }
}

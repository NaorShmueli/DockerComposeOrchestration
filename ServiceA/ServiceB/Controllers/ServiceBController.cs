using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public ServiceBController(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            service_c_url = configuration["ServiceCUrl"];
        }
        [HttpGet("data")]
        public async Task<IActionResult> GetData()
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetAsync(service_c_url);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public ServiceCController(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            service_a_url = configuration["ServiceAUrl"];
        }
        [HttpGet("data")]
        public async Task<IActionResult> GetData()
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetAsync(service_a_url);
            return Ok(result);
        }
    }
}

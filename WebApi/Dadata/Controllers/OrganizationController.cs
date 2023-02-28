using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dadata.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dadata.Controllers
{
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IConfiguration _config;

        public OrganizationController(IConfiguration config)
        {
            _config = config;
        }

        public List<Organization> organizations = new List<Organization>( new[] {
            new Organization { Inn = "123", Name = "Сбер" },
            new Organization { Inn = "223", Name = "Альфа" }
        });

        [HttpGet("{inn}")]     
        public IActionResult Get(string inn)
        {
            var organization = organizations.SingleOrDefault(o => o.Inn == inn);

            if (organization == null)
                return NotFound();

            return Ok(organization.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var token = _config.GetSection("Tokens:DadataToken");
            var api = new SuggestClientAsync(token);
            return Ok();
        }
    }
}
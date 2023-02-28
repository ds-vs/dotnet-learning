using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dadata;
using Microsoft.AspNetCore.Mvc;
using WebApplication02.Models;

namespace WebApplication02.Controllers
{
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IConfiguration _config;

        public OrganizationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{inn}")]
        public async Task<IActionResult> GetOrganizationName(string inn)
        {
            string token = _config.GetSection("Tokens:DadataToken").Value;
            var api = new SuggestClientAsync(token);
            var response = await api.FindParty(inn);
            var party = response.suggestions[0].data.name.full;

            return Ok(party);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacilitiesAPI.DAL;
using FacilitiesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacilitiesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TankController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TankController(AppDbContext context)
        {
            _context = context;
        }   
    }
}
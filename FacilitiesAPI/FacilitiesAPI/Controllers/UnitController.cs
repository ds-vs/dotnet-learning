using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacilitiesAPI.DAL;
using FacilitiesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UnitController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAll()
        {
            return await _context.Units.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Unit>> GetUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
                return NotFound();

            return Ok(unit);    
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> PostUnit(Unit newUnit)
        {
            _context.Units.Add(newUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnit), new { id = newUnit.Id }, newUnit);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Unit>> DeleteUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
                return NotFound();

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
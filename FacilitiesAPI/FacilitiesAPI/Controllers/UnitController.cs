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

        private bool UnitExists(int id) => _context.Units.Any(u => u.Id == id);

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAll()
        {
            return await _context.Units.ToListAsync();
        }

        [HttpGet("{unitId}")]
        public async Task<ActionResult<Unit>> GetUnit(int unitId)
        {
            var unit = await _context.Units.FindAsync(unitId);

            if (unit == null)
                return NotFound();

            return Ok(unit);    
        }

        [HttpPost()]
        public async Task<ActionResult<Unit>> PostUnit(string name, string description)
        {
            var unit = new Unit()
            {
                Name = name,
                Description = description
            };

            _context.Units.Add(unit);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{unitId}")]
        public async Task<ActionResult<Unit>> DeleteUnit(int unitId)
        {
            var unit = await _context.Units.FindAsync(unitId);

            if (unit == null)
                return NotFound();

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{unitId}")]
        public async Task<ActionResult<Unit>> UpdateUnit(int unitId, string name, string description)
        {
            var unit = new Unit() 
            {
                Id = unitId,
                Name = name,
                Description = description
            };

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(unitId))
                    return NotFound();
                else
                    throw;
            }
            return Ok();
        }
    }
}

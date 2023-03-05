using FacilitiesAPI.DAL;
using FacilitiesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TankController : ControllerBase
    {
        private readonly AppDbContext _context;

        private bool UnitExists(int id) => _context.Units.Any(u => u.Id == id);

        public TankController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{tankId}")]
        public async Task<ActionResult<Tank>> Get(int tankId)
        {
            var tank = await _context.Tanks.FindAsync(tankId);

            if (tank == null)
                return NotFound();

            return Ok(tank);
        }

        [HttpPost("unit/{unitId}")]
        public async Task<ActionResult<Tank>> PostTank(string name, string description, int volume, int maxVolume, int unitId)
        {
            var newTank = new Tank()
            {
                Name = name,
                Description = description,
                Volume = volume,
                MaxVolume = maxVolume,
                UnitId = unitId,
            };

            _context.Tanks.Add(newTank);

            if (!UnitExists(unitId))
            {
                return NotFound();
            }
            else
            {
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut("{tankId}")]
        public async Task<ActionResult<Tank>> PutTank(int tankId, string name, string description, int maxVolume, int volume, int unitId)
        {
            var tank = new Tank()
            {
                Id = tankId,
                Name = name,
                Description = description,
                Volume = volume,
                MaxVolume = maxVolume,
                UnitId = unitId
            };

            _context.Entry(tank).State = EntityState.Modified;

            if (UnitExists(tankId) && UnitExists(unitId))
                await _context.SaveChangesAsync();
            else
                return NotFound();

            return Ok();
        }

        [HttpDelete("tankId")]
        public async Task<ActionResult<Tank>> DeleteTank(int tankId)
        {
            var tank = await _context.Tanks.FindAsync(tankId);

            if (tank == null)
                return NotFound();

            _context.Tanks.Remove(tank);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

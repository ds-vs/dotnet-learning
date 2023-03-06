using FacilitiesAPI.DAL.Intefaces;
using FacilitiesAPI.DAL.Repository;
using FacilitiesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.Controllers
{
    public abstract class BaseController<TEntity, TRepository> : ControllerBase 
        where TEntity : class, IEntity
        where TRepository : IBaseRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var model = await _repository.Get(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity model)
        {
            await _repository.Add(model);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        // DELETE: api/[controller]/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var unit = await _repository.Delete(id);

            if (unit == null)
                return NotFound();

            return Ok();
        }

        // PUT: api/[controller]/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUnit(int id, TEntity model)
        {
            if (id != model.Id)
                return BadRequest();

            await _repository.Update(model);
            return NoContent();
        }
    }
}

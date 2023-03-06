using FacilitiesAPI.DAL.Intefaces;
using FacilitiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.DAL.Repository
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext Context;

        public BaseRepository(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> Add(TEntity model)
        {
            Context.Set<TEntity>().Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public async Task<TEntity> Delete(int id)
        {
            var model = await Context.Set<TEntity>().FindAsync(id);

            if (model == null)
                return null!;

            Context.Remove(model);

            await Context.SaveChangesAsync();

            return model;
        }

        public async Task<TEntity> Get(int id)
        {
            var model = await Context.Set<TEntity>().FindAsync(id);

            return model!;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity model)
        {
            Context.Entry(model).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return model;
        }
    }
}

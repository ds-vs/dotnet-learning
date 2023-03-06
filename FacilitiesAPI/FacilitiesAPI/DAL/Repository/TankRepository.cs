using FacilitiesAPI.Models;

namespace FacilitiesAPI.DAL.Repository
{
    public class TankRepository : BaseRepository<TankEntity, AppDbContext>
    {
        public TankRepository(AppDbContext context) : base(context) { }
    }
}

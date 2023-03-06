using FacilitiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.DAL.Repository
{
    public class UnitRepository : BaseRepository<UnitEntity, AppDbContext>
    {
        public UnitRepository(AppDbContext context): base(context) { }
    }
}

using FacilitiesAPI.DAL.Repository;
using FacilitiesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacilitiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankController : BaseController<TankEntity, TankRepository>
    {
        public TankController(TankRepository repository) : base(repository) { }
    }
}

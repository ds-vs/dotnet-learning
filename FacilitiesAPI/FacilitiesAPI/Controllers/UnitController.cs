using FacilitiesAPI.DAL;
using FacilitiesAPI.DAL.Intefaces;
using FacilitiesAPI.DAL.Repository;
using FacilitiesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : BaseController<UnitEntity, UnitRepository>
    {
        public UnitController(UnitRepository repository) : base(repository) { }
    }
}

using AvailabilityAPI.DAL;
using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvailabilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly AvailabilityDbContext _dbContext;

        public AvailabilityController(AvailabilityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities()
        {
            return _dbContext.Availabilities;
        }
    }
}

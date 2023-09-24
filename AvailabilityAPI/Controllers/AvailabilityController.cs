using AvailabilityAPI.Data;
using AvailabilityAPI.Models;
using AvailabilityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvailabilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _service;

        public AvailabilityController(IAvailabilityService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities()
        {
            return _service.GetAllAvailabilities();
        }
        
    }
}

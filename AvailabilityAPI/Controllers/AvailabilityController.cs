using AvailabilityAPI.Data;
using AvailabilityAPI.Models;
using AvailabilityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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



        [HttpPost]
        public async Task<ActionResult> CreateNewAvailability(AvailabilityTable availability)
        {
            int id = await _service.AddAvailability(availability);
            return Ok(id);
        }

        [HttpPost("examcenters")]
        public async Task<IEnumerable<Availability>> GetAvailabilitiesInRegion(AvailabilityRequestModel req)
        {
            var availabilities = await _service.AllAvailabilitiesWithinUserRegion(req.duration, req.zipcode, req.distanceInMiles);
            return availabilities;
        }

    }
}

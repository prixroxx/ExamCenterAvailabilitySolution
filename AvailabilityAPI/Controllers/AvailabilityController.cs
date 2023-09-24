using AvailabilityAPI.Data;
using AvailabilityAPI.Models;
using AvailabilityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvailabilityAPI.Controllers
{
    [Route("availability")]
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



        [HttpPost("create")]
        public async Task<ActionResult> CreateNewAvailability(AvailabilityTable availability)
        {
            int id = await _service.AddAvailability(availability);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IEnumerable<Availability>> GetAvailabilitiesInRegion(AvailabilityRequestModel req)
        {
            var availabilities = await _service.AllAvailabilitiesWithinUserRegion(req.duration, req.zipcode, req.distanceInMiles);
            return availabilities;
        }

        [HttpGet("~/test")]
        public string TestAPIIsRunning()
        {
            return "Hello World!!";
        }

        /* Book Slot Functionality Remaining. Will Come Here. */
    }
}

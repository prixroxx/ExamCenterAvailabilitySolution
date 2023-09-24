using AvailabilityAPI.Data;
using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvailabilityAPI.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly AvailabilityDbContext _context;
        public AvailabilityService(AvailabilityDbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities()
        {
            return _context.Availabilities;
        }

    }
}

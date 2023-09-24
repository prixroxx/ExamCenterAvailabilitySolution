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

        #region[Functions]

        public ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities()
        {
            return _context.Availabilities;
        }

        public async Task<int> AddAvailability(AvailabilityTable availability)
        {
            try
            {
                await _context.Availabilities.AddAsync(availability);
                await _context.SaveChangesAsync();
                return availability.Id;
            }
            catch (Exception ex)
            {
                return -9999;
            }

        }
        #endregion
    }
}

using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvailabilityAPI.Services
{
    public interface IAvailabilityService
    {
        ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities();
    }
}
using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvailabilityAPI.Services
{
    public interface IAvailabilityService
    {
        ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities();

        Task<int> AddAvailability(AvailabilityTable availability);

        Task<ExamCenterTable> IsExamCenterActive(int examCenterId);

        Task<IEnumerable<Availability>> AllAvailabilitiesWithinUserRegion(int duration, string zipcode, double distanceInMiles);
    }
}
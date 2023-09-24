using AvailabilityAPI.Models;

namespace AvailabilityAPI.Services
{
    public interface ILocationService
    {
        double GetDistanceInMiles(ZipCodeCenterPoint userPoint, ZipCodeCenterPoint examPoint);

        ZipCodeCenterPoint GetZipCodeInfo(string zipCode);
    }
}
using AvailabilityAPI.Data;
using AvailabilityAPI.Models;

namespace AvailabilityAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly AvailabilityDbContext _context;
        public LocationService(AvailabilityDbContext context)
        {
            _context = context;
        }

        private Dictionary<string, ZipCodeCenterPoint> _zipCodes = new Dictionary<string, ZipCodeCenterPoint>{
                                                                    { "11111", new ZipCodeCenterPoint("11111", 45.22738570006638, -93.9960240952021) },
                                                                    { "22222", new ZipCodeCenterPoint("22222", 45.56189444715879, -93.22693539547762) },
                                                                    { "33333", new ZipCodeCenterPoint("33333", 44.84908604562181, -92.23998199472152) }
                                                                };

        public ZipCodeCenterPoint GetZipCodeInfo(string zipCode)
        {
            return _zipCodes[zipCode];
        }

        private static double toRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th
            // of a degree
            return (angleIn10thofaDegree * Math.PI) / 180;
        }

        /// <summary>
        /// Calculate Distance between two zipcodes
        /// </summary>
        /// <param name="userPoint"></param>
        /// <param name="examPoint"></param>
        /// <returns></returns>
        public double GetDistanceInMiles(ZipCodeCenterPoint userPoint, ZipCodeCenterPoint examPoint)
        {
            double lonExam = toRadians(examPoint.Longtitude);
            double lonUser = toRadians(userPoint.Longtitude);
            double latExam = toRadians(examPoint.Latitude);
            double latUser = toRadians(userPoint.Latitude);

            // Haversine formula
            double dlon = lonUser - lonExam;
            double dlat = latUser - latExam;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(latExam) * Math.Cos(latUser) * Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in miles
            double r = 3956;

            // calculate the result
            return (c * r);
        }
    }
}

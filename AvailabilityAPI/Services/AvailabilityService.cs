using AvailabilityAPI.Data;
using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvailabilityAPI.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        #region[Declarations]

        private readonly AvailabilityDbContext _context;
        public AvailabilityService(AvailabilityDbContext context)
        {
            _context = context;
        }

        private Dictionary<string, ZipCodeCenterPoint> _zipCodes = new Dictionary<string, ZipCodeCenterPoint>{
                                                                    { "11111", new ZipCodeCenterPoint("11111", 45.22738570006638, -93.9960240952021) },
                                                                    { "22222", new ZipCodeCenterPoint("22222", 45.56189444715879, -93.22693539547762) },
                                                                    { "33333", new ZipCodeCenterPoint("33333", 44.84908604562181, -92.23998199472152) },
                                                                    { "12345", new ZipCodeCenterPoint("33333", 47.84908604562181, -98.23998199472152) },
                                                                    { "67890", new ZipCodeCenterPoint("33333", 46.84908604562181, -94.23998199472152) }
                                                                };

        #endregion

        #region[Availability Functions]

        public ActionResult<IEnumerable<AvailabilityTable>> GetAllAvailabilities()
        {
            return _context.Availabilities;
        }

        public async Task<int> AddAvailability(AvailabilityTable availability)
        {
            try
            {
                var examCenterID = availability.ExamCenterID;
                if(await IsExamCenterActive(examCenterID)!=null)
                {
                    await _context.Availabilities.AddAsync(availability);
                    await _context.SaveChangesAsync();
                    return availability.Id;
                }
                return -9999;
            }
            catch (Exception ex)
            {
                return -9999;
            }

        }

        public async Task<IEnumerable<Availability>> AllAvailabilitiesWithinUserRegion(int duration, string zipcode, double distanceInMiles)
        {
            try
            {
                var availabilitiesList = await _context.Availabilities.ToListAsync();

                
                List<Availability> result = new List<Availability>();

                foreach(var ava in availabilitiesList)
                {
                    var start = ava.StartTime;
                    var end = ava.EndTime;
                    TimeSpan ts = end - start;
                    if(ts.TotalMinutes > duration)
                    {
                        if (_zipCodes.ContainsKey(zipcode))
                        {
                            ZipCodeCenterPoint userLoc = _zipCodes[zipcode];
                            var center = await IsExamCenterActive(ava.ExamCenterID);
                            ZipCodeCenterPoint examLoc = _zipCodes[center.ZipCode];
                            double distance = GetDistanceInMiles(userLoc, examLoc);
                            if(distance < distanceInMiles && (ava.SeatCount-ava.AvailableSeats >= 1) && (ava.IsActive))
                            {
                                Availability availability = new Availability();
                                availability.Id = ava.Id;
                                availability.Name = center.Name;
                                availability.StartTime = ava.StartTime;
                                availability.Address = center.ZipCode;
                                availability.Longitude = examLoc.Longtitude;
                                availability.Latitude = examLoc.Latitude;
                                availability.DistanceMiles = distance;
                                result.Add(availability);
                            }
                        }
                            
                    }
                }

                return result;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExamCenterTable> IsExamCenterActive(int examCenterId)
        {
            try
            {
                var center = await _context.ExamCenters.FindAsync(examCenterId);
                if (center != null && center.IsActive)
                {
                    return center;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }          
        }
        #endregion

        #region[Location Functions]

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

        #endregion
    }
}

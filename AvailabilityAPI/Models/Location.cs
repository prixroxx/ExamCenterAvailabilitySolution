namespace AvailabilityAPI.Models
{
    public class Location
    {
        private Dictionary<string, ZipCodeCenterPoint> _zipCodes = new Dictionary<string, ZipCodeCenterPoint>{
                                                                    { "11111", new ZipCodeCenterPoint("11111", 45.22738570006638, -93.9960240952021) },
                                                                    { "22222", new ZipCodeCenterPoint("22222", 45.56189444715879, -93.22693539547762) },
                                                                    { "33333", new ZipCodeCenterPoint("33333", 44.84908604562181, -92.23998199472152) }
                                                                };

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double DistanceInMiles { get; set; }
    }
}

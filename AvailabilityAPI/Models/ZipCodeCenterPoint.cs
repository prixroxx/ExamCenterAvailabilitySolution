namespace AvailabilityAPI.Models
{
    public class ZipCodeCenterPoint
    {
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public ZipCodeCenterPoint(string zipCode, double latitude, double longtitude)
        {
            ZipCode = zipCode;
            Latitude = latitude;
            Longtitude = longtitude;
        }
    }
}
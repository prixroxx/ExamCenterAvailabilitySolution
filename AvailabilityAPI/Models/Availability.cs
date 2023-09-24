using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvailabilityAPI.Models
{
    public class Availability
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime StartTime { get; set; }

        public int Seats { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double DistanceMiles { get; set; }
    }

}

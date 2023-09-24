using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AvailabilityAPI.Models
{
    [Table("availability", Schema = "dbo")]
    public class AvailabilityTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("examcenterid")]
        public int ExamCenterID { get; set; }

        [Column("starttime")]
        public DateTime StartTime { get; set; }

        [Column("endtime")]
        public DateTime EndTime { get; set; }

        [Column("seatcount")]
        public int SeatCount { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AvailabilityAPI.Models
{
    [Table("examcenter", Schema = "dbo")]
    public class ExamCenterTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("zipcode")]
        public string ZipCode { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

    }
}

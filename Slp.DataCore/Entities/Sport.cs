using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.DataCore.Entities
{
    public class Sport: BaseTab
    {
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public bool? IsMondayTraining { get; set; }
        public bool? IsTuesdayTraining { get; set; }
        public bool? IsWednesdayTraining { get; set; }
        public bool? IsThursdayTraining { get; set; }
        public bool? IsFridayTraining { get; set; }
        public bool? IsSaturdayTraining { get; set; }
        public bool? IsSundayTraining { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}

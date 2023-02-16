using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.Data.Entities
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
        public virtual ICollection<DayOfWeek> TrainingDays { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

    }
}

using Slp.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.Data.Entities
{
    public class Lesson:BaseEntity
    {
        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public DateTime StartDateAndTime { get; set; }
        [Required]
        public int DurationMins { get; set; }
        [Required]
        public LessonType Type { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Venue { get; set; }

        public virtual Subject Subject { get; set; }
    }
}

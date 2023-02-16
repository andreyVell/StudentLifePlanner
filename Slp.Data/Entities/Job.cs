using Slp.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.Data.Entities
{
    public class Job:BaseTab
    {
        [Column(TypeName = "varchar(300)")]
        public string? Description { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public TimeOnly? StartWorkingDayTime { get; set; }
        public TimeOnly? EndWorkingDayTime { get; set; }
    }
}

using Slp.DataCore.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.DataCore.Entities
{
    public class Job:BaseTab
    {
        [Column(TypeName = "varchar(300)")]
        public string? Description { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public DateTime? StartWorkingDayTime { get; set; }
        public DateTime? EndWorkingDayTime { get; set; }
    }
}

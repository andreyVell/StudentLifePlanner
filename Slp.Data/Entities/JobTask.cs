using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class JobTask:BaseTask
    {
        [Required]
        public Guid JobId { get; set; }
        public double? HoursSpent { get; set; }
        public DateTime? CompletionDate { get; set; }

        public virtual Job Job { get; set; }
    }
}

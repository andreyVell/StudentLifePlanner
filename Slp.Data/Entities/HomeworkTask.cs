using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class HomeworkTask:BaseTask
    {
        [Required]
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}

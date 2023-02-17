using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.DataCore.Entities
{
    public abstract class BaseTask : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(400)")]
        public string? Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public DateTime DeadLineDate { get; set; }
    }
}

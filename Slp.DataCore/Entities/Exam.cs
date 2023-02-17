using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.DataCore.Entities
{
    public class Exam : BaseEntity
    {
        [Required]
        public Guid SubjectId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(75)")]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? Description { get; set; }

        public virtual Subject Subject { get; set; }
    }
}

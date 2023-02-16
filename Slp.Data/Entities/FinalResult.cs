using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.Data.Entities
{
    public class FinalResult : BaseEntity
    {
        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }
        [Required]
        public double Score { get; set; }

        public virtual Subject Subject { get; set; }
    }
}

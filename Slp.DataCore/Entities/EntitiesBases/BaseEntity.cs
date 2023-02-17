using System.ComponentModel.DataAnnotations;

namespace Slp.DataCore.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public Guid CreatedById { get; set; }        
        public DateTime? ModifyAt { get; set; }
        public Guid? ModifyById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User? ModifyBy { get; set; }
    }
}
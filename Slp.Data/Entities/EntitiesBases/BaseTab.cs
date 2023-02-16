using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.Data.Entities
{
    public abstract class BaseTab : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? MainLogoUrl { get; set; }
    }
}

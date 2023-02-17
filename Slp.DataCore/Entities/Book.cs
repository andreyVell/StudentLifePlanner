using Slp.DataCore.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.DataCore.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Author { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? Description { get; set; }
        [Required]
        public ReadingBookStatus ReadingStatus { get; set; }

        public int? TotalNumberOfPages { get; set; }
        public int? CurrentPage { get; set; }
        public DateTime? StartReadingDate { get; set; }
        public DateTime? EndReadingDate { get; set; }
    }
}

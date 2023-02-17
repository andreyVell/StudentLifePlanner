using Slp.DataCore.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slp.DataCore.Entities
{
    public class Vacancy:BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(75)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string LinkToJobSite { get; set; }
        [Column(TypeName = "varchar(75)")]
        public string RecruiterName { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string RecruiterContact { get; set; }
        public VacancyStatus CurrentStatus { get; set; }

    }
}

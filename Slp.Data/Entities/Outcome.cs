using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class Outcome:BaseIncome
    {
        [Required]
        public DateTime Date { get; set; }
    }
}

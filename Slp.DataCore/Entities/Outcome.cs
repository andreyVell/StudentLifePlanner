using System.ComponentModel.DataAnnotations;

namespace Slp.DataCore.Entities
{
    public class Outcome:BaseIncome
    {
        [Required]
        public DateTime Date { get; set; }
    }
}

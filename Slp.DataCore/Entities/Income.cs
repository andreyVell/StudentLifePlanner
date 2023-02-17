using System.ComponentModel.DataAnnotations;

namespace Slp.DataCore.Entities
{
    public class Income:BaseIncome
    {
        [Required]
        public DateTime Date { get; set; }
    }
}

using Slp.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class PeriodicOutcome:BaseIncome
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public IncomePeriodType Period { get; set; }
        [Required]
        public int OutcomeDayOfPeriod { get; set; }
    }
}

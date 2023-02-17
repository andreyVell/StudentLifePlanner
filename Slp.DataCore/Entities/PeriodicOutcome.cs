using Slp.DataCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace Slp.DataCore.Entities
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

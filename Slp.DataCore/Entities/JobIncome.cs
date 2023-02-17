using Slp.DataCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace Slp.DataCore.Entities
{
    public class JobIncome:BaseIncome
    {
        [Required]
        public Guid JobId { get; set; }
        [Required]
        public IncomePeriodType Period { get; set; }
        [Required]
        public int IncomeDayOfPeriod { get; set; }

        public virtual Job Job { get; set; }
    }
}

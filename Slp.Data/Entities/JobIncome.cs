using Slp.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
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

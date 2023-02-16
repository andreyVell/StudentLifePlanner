using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class TrainingPlan:BaseTab
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Slp.Data.Entities
{
    public class UserSettings
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public TimeOnly? WakeUpTime { get; set; }
        public TimeOnly? SleepTime { get; set; }
        public TimeOnly? WorkStartTime { get; set; }
        public TimeOnly? WorkEndTime { get; set;}
        public TimeOnly? RelaxStartTime { get; set; }
        public TimeOnly? RelaxEndTime { get; set; }
        public string? ActiveSections { get; set; }

        public virtual User User { get; set; }
    }
}

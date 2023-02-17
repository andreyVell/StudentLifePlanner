using System.ComponentModel.DataAnnotations;

namespace Slp.DataCore.Entities
{
    public class UserSetting
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public DateTime? WakeUpTime { get; set; }
        public DateTime? SleepTime { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public DateTime? WorkEndTime { get; set;}
        public DateTime? RelaxStartTime { get; set; }
        public DateTime? RelaxEndTime { get; set; }
        public string? ActiveSections { get; set; }

        public virtual User User { get; set; }
    }
}

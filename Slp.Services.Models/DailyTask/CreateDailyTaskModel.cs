namespace Slp.Services.Models.DailyTask
{
    public class CreateDailyTaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DeadLineDate { get; set; }
    }
}

namespace Slp.Services.Models.DailyTask
{
    public class EditDailyTaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descriprion { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DeadLineDate { get; set; }
    }
}

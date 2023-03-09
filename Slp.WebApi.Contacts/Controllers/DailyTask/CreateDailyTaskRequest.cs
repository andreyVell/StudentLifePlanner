namespace Slp.WebApi.Contracts.Controllers.DailyTask
{
    public class CreateDailyTaskRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IsCompleted { get; set; }
        public string? DeadLineDate { get; set; }
    }
}

namespace Slp.WebApi.Contracts.Controllers.DailyTask
{
    public class EditDailyTaskRequest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IsCompleted { get; set; }
        public string? DeadLineDate { get; set; }
    }
}

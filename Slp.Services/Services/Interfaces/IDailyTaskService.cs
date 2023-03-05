using Slp.Services.Models.DailyTask;

namespace Slp.Services.Services.Interfaces
{
    public interface IDailyTaskService : IServiceRegistrator
    {
        Task<List<GetDailyTaskModel>> GetAllAsync();
        Task<GetDailyTaskModel> GetAsync(Guid dailyTaskId);
        Task<Guid> EditAsync(EditDailyTaskModel dailyTask);
        Task DeleteAsync(Guid dailyTaskId);
        Task<Guid> CreateAsync(CreateDailyTaskModel dailyTask);
    }
}

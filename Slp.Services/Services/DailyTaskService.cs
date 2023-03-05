using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Slp.DataCore.Entities;
using Slp.DataCore.Exceptions.DailyTask;
using Slp.DataCore.Exceptions.User;
using Slp.DataProvider;
using Slp.Services.Models;
using Slp.Services.Models.DailyTask;
using Slp.Services.Services.Interfaces;

namespace Slp.Services.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DailyTaskService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<Guid> CreateAsync(CreateDailyTaskModel dailyTask)
        {
            var newDailyTask = new DailyTask();
            newDailyTask.CreatedAt = DateTime.UtcNow;
            newDailyTask.CreatedById = _currentUserService.GetCurrentUserId();
            newDailyTask.Name = dailyTask.Name;
            newDailyTask.DeadLineDate = dailyTask.DeadLineDate;
            newDailyTask.Description = dailyTask.Descriprion;
            newDailyTask.IsCompleted = dailyTask.IsCompleted;
            var result = await _unitOfWork.DailyTasks.InsertAsync(newDailyTask);
            return result.Id;
        }

        public async Task DeleteAsync(Guid dailyTaskId)
        {
            var dailyTask = await _unitOfWork.DailyTasks.GetFirstWhereAsync(e=>e.Id == dailyTaskId);
            await _unitOfWork.DailyTasks.DeleteAsync(dailyTask);
        }

        public async Task<Guid> EditAsync(EditDailyTaskModel dailyTask)
        {
            var dbDailyTask = await _unitOfWork.DailyTasks.GetFirstWhereAsync(e => e.Id == dailyTask.Id);
            if (dbDailyTask == null)
            {
                throw new DailyTaskDoesNotExistException();
            }
            dbDailyTask.DeadLineDate = dailyTask.DeadLineDate;
            dbDailyTask.Description = dailyTask.Descriprion;
            dbDailyTask.IsCompleted = dailyTask.IsCompleted;
            dbDailyTask.ModifyAt = DateTime.UtcNow;
            dbDailyTask.ModifyById = _currentUserService.GetCurrentUserId();
            dbDailyTask.Name = dailyTask.Name;
            var result = await _unitOfWork.DailyTasks.UpdateAsync(dbDailyTask);
            return result.Id;
        }

        public async Task<List<GetDailyTaskModel>> GetAllAsync()
        {
            var dailyTasks = await _unitOfWork.DailyTasks.FindAllByWhereAsync(e => e.CreatedById == _currentUserService.GetCurrentUserId());            
            return _mapper.Map<List<GetDailyTaskModel>>(dailyTasks);
        }

        public async Task<GetDailyTaskModel> GetAsync(Guid dailyTaskId)
        {
            var dailyTask = await _unitOfWork.DailyTasks.GetFirstWhereAsync(e => e.Id == dailyTaskId);
            return _mapper.Map<GetDailyTaskModel>(dailyTask);
        }
    }
}

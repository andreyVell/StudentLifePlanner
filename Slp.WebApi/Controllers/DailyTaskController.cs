using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slp.Services.Models.DailyTask;
using Slp.Services.Services;
using Slp.Services.Services.Interfaces;
using Slp.WebApi.Contracts.Controllers.DailyTask;
using Slp.WebApi.Contracts.Controllers.User;

namespace Slp.WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class DailyTaskController : ApiControllerBase
    {
        private readonly IDailyTaskService _dailyTaskService;
        private readonly IMapper _mapper;

        public DailyTaskController(
            IDailyTaskService dailyTaskService,
            IMapper mapper)
        {
            _dailyTaskService = dailyTaskService;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        [ProducesResponseType(typeof(GetDailyTasksResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dailyTasks = await _dailyTaskService.GetAllAsync();
                var responce = new GetDailyTasksResponse()
                {
                    Items = _mapper.Map<List<GetDailyTaskResponse>>(dailyTasks),
                    Total = dailyTasks.Count,
                };
                return Ok(responce);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }


        [HttpGet("{dailyTaskId}"), Authorize]
        [ProducesResponseType(typeof(GetDailyTaskResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid dailyTaskId)
        {
            try
            {
                var dailyTask = await _dailyTaskService.GetAsync(dailyTaskId);
                var responce = _mapper.Map<GetDailyTaskResponse>(dailyTask);
                return Ok(responce);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }


        [HttpPost, Authorize]
        [ProducesResponseType(typeof(CreateDailyTaskResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateDailyTaskRequest requestDailyTask)
        {
            try
            {
                var newDailyTask = _mapper.Map<CreateDailyTaskModel>(requestDailyTask);
                var newDailyTaskId = await _dailyTaskService.CreateAsync(newDailyTask);
                return Ok(new CreateDailyTaskResponse() { Id = newDailyTaskId });
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }



        [HttpDelete("{dailyTaskId}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid dailyTaskId)
        {
            try
            {
                await _dailyTaskService.DeleteAsync(dailyTaskId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPut, Authorize]
        [ProducesResponseType(typeof(EditDailyTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(EditDailyTaskRequest request)
        {
            try
            {
                var editDailyTaskModel = _mapper.Map<EditDailyTaskModel>(request);
                var editDailyTaskId = await _dailyTaskService.EditAsync(editDailyTaskModel);

                return Ok(new EditDailyTaskResponse() { Id = editDailyTaskId });
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}

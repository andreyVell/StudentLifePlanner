using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slp.Services.Models.User;
using Slp.Services.Services.Interfaces;
using Slp.WebApi.Contracts.Controllers.User;

namespace Slp.WebApi.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public UserController(
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
        }


        [HttpGet, Authorize]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _currentUserService.GetCurrentUserAsync();                
                var responce = _mapper.Map<GetUserResponse>(user);
                return Ok(responce);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }


        [HttpPut, Authorize]
        [ProducesResponseType(typeof(EditUserRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(EditUserRequest request)
        {
            try
            {                
                var editUserModel = _mapper.Map<EditUserModel>(request);
                var userId = await _currentUserService.EditCurrentUserAsync(editUserModel);
                return Ok(new EditUserResponse { Id = userId });

            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}

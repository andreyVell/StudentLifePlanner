using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Slp.Services.Models.User;
using Slp.Services.Services.Interfaces;
using Slp.WebApi.Contracts.Controllers.Registration.CreateUser;

namespace Slp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ApiControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IMapper _mapper;
        public RegistrationController(
            IRegistrationService registrationService, 
            IMapper mapper)
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("/Registration")]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Registration(CreateUserRequest request)
        {          
            try
            {
                var newUser = _mapper.Map<CreateUserModel>(request);
                var userId = await _registrationService.CreateNewUserAsync(newUser);
                return Ok(new CreateUserResponse { Id = userId });                
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}

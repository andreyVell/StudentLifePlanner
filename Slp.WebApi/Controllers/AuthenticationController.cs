using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Slp.Services.Models.User;
using Slp.Services.Services.Interfaces;
using Slp.WebApi.Contracts.Controllers.Authentication;

namespace Slp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;


        public AuthenticationController(
            IAuthenticationService authenticationService,
            IMapper mapper)
        {            
            _authenticationService = authenticationService;
            _mapper = mapper;
        }   

        [HttpPost]
        [Route("/Login")]
        [ProducesResponseType(typeof(LoginUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            
            try
            {      
                var newUser = _mapper.Map<LoginUserModel>(request);
                var token = await _authenticationService.LoginAsync(newUser);
                return Ok(new LoginUserResponse { Token = token });
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        } 
    }
}

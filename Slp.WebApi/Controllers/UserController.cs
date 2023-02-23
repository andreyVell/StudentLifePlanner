using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slp.Services.Services.Interfaces;

namespace Slp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        public UserController(
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [HttpGet, Authorize]
        [Route("/get_me")]
        public ActionResult<Guid> GetMe()
        {
            return Ok(_currentUserService.GetCurrentUserId());
        }
    }
}

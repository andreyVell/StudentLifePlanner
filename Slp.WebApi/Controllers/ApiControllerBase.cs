using Microsoft.AspNetCore.Mvc;
using Slp.DataCore.Exceptions;
using System.Net;

namespace Slp.WebApi.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ExceptionResult(Exception exception)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, exception.Message);
        }
    }
}

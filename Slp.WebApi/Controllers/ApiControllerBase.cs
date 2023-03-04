using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Slp.DataCore.Exceptions;
using System.Net;

namespace Slp.WebApi.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ExceptionResult(Exception exception)
        {
            var error = new ApiErrorResponce();
            error.ErrorMessage = exception.Message;
            return StatusCode((int)HttpStatusCode.BadRequest, error);
        }
    }
}

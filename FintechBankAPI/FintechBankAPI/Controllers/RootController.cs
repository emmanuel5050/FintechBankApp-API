using FintechBankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FintechBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        /// <summary>
        /// Returns the appropriate HTTP Response.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        protected IActionResult ProcessResponse(Response data)
        {
            if(data.Success) return Ok(data);
            switch (data.Status)
            {
                case 401:
                    return Unauthorized(data);
                case 403:
                    return StatusCode((int)HttpStatusCode.Forbidden, data);
                case 404:
                    return NotFound(data);
                case 500:
                    return StatusCode((int)HttpStatusCode.InternalServerError, data);
                default:
                    return StatusCode((int)HttpStatusCode.BadRequest, data);
            }

        }
    }
}


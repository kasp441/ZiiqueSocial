using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ZiiqueSocialBackend.Controller
{
    [ApiController]
    [Route("api")]
    public class UserProfileController : ControllerBase
    {

        [HttpGet]
        [Route("HelloWorld")]
        public IActionResult Get()
        {
            return Ok("hello");
        }
    }
}

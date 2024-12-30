
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repo;

namespace ZiiqueSocialBackend.Controller
{
    [ApiController]
    [Route("requestData")]
    public class RequestDataController : ControllerBase
    {
        IRequestData _requestData;
        public RequestDataController(IRequestData requestData)
        {
            _requestData = requestData;
        }

        [HttpGet]
        public IActionResult GetRequestData(Guid id)
        {
            var data = _requestData.GetProfileData(id);
            return Ok(data);
        }
    }
}

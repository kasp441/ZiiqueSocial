using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZiiqueSocialBackend.Controller
{
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        IUserService _userService;
        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("createProfile")]
        public IActionResult CreateUser(ProfileDto profileDto)
        {
            return Ok(_userService.CreateUser(profileDto));
        }
        
        [HttpGet]
        public IActionResult GetUser([FromQuery] Guid id)
        {
            return Ok(_userService.GetUser(id));
        }
    }
}

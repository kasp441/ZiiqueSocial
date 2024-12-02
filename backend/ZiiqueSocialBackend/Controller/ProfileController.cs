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
        public IActionResult CreateUser(ProfileDto profileDto, string authId)
        {
            return Ok(_userService.CreateUser(profileDto, authId));
        }
    }
}

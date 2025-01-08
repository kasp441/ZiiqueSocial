using System.IdentityModel.Tokens.Jwt;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZiiqueSocialBackend.Controller
{
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        IUserService _userService;
        IPAuthService _authService;
        public ProfileController(IUserService userService, IPAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [Authorize]
        [HttpPost]
        [Route("createProfile")]
        public IActionResult CreateUser(ProfileDto profileDto)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            Guid newProfileId = _userService.CreateUser(profileDto, authId);
            return Ok(newProfileId);
        }
        
        [HttpGet]
        public IActionResult GetUser([FromQuery] Guid id)
        {
            return Ok(_userService.GetUser(id));
        }
    }
}

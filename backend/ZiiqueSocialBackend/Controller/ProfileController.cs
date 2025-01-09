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
        private readonly IUserService _userService;
        private readonly ILogger<ProfileController> _logger;    
        public ProfileController(IUserService userService, ILogger<ProfileController> logger)   
        {
            _logger = logger;
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        [Route("createProfile")]
        public IActionResult CreateUser(ProfileDto profileDto)
        {
            try
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                var token = authHeader.Substring("Bearer ".Length).Trim();
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
                Guid newProfileId = _userService.CreateUser(profileDto, authId);
                return Ok(newProfileId);
            } catch (Exception e)
            {
                _logger.LogError(e, "Error creating user");
                return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
            }   
        }
        
        [HttpGet]
        public IActionResult GetUser([FromQuery] Guid id)
        {
            try
            {
                return Ok(_userService.GetUser(id));
            } catch (Exception e)
            {
                _logger.LogError(e, "Error getting user");
                return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");  
            }
        }
    }
}

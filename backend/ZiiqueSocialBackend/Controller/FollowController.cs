using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZiiqueSocialBackend.Controller;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FollowController : ControllerBase
{
    private readonly IFollowService _followService;
    
    public FollowController(IFollowService followService)
    {
        _followService = followService;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Follow(Guid followingId)
    {
        try
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            await _followService.Follow(authId, followingId);
            return Ok();
        } catch (Exception e)
        {
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Unfollow(Guid followingId)
    {
        try
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            await _followService.Unfollow(authId, followingId);
            return Ok();
        } catch (Exception e)
        {
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetFollowers()
    {
        try
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var authId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "sub").Value);
            var followers = await _followService.GetFollowers(authId);
            return Ok(followers);
        } catch (Exception e)
        {
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
}
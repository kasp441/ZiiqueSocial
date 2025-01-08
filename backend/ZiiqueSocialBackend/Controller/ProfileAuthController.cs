using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZiiqueSocialBackend.Controller;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProfileAuthController : ControllerBase
{
    private readonly IPAuthService _profileAuthService;
    
    public ProfileAuthController(IPAuthService profileAuthService)
    {
        _profileAuthService = profileAuthService;
    }
    
    [HttpGet("{authId}")]
    public async Task<IActionResult> CheckIfExistPa(Guid authId)
    {
        try
        {
            bool exists = await _profileAuthService.CheckIfExistPa(authId);
            return Ok(exists);
        } catch (Exception e)
        {
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
}
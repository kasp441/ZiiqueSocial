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
    private readonly ILogger<ProfileAuthController> _logger;
    
    public ProfileAuthController(IPAuthService profileAuthService, ILogger<ProfileAuthController> logger)
    {
        _profileAuthService = profileAuthService;
        _logger = logger;
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
            _logger.LogError(e, "Error checking if profile exists {authId}", authId);
            return StatusCode(500, "It seems we cant quite get the posts right now, please try again later.");
        }
    }
}
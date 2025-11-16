using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var email = User.FindFirstValue(ClaimTypes.Email) ?? "(unknown)";
        var role = User.FindFirstValue(ClaimTypes.Role) ?? "(none)";
        var sub  = User.FindFirstValue(ClaimTypes.NameIdentifier) 
                   ?? User.FindFirstValue(ClaimTypes.Name) 
                   ?? "(id)";

        return Ok(new { sub, email, role });
    }
}
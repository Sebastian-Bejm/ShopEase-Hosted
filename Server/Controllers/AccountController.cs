using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpGet("user")]
    public IActionResult GetUser()
    {
        var isAuthenticated = User.Identity?.IsAuthenticated ?? false;
        var userName = isAuthenticated ? User.Identity?.Name ?? "" : "";

        return Ok(new
        {
            IsAuthenticated = isAuthenticated,
            UserName = userName
        });
    }
}

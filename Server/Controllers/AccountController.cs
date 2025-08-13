using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Shared.Models;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpGet("user")]
    [Authorize]
    public IActionResult GetUser()
    {
        var user = User;

        if (user.Identity?.IsAuthenticated ?? false)
        {
            return Ok(new UserInfo
            {
                IsAuthenticated = true,
                UserName = user.Identity.Name
            });
        }

        return Ok(new UserInfo
        {
            IsAuthenticated = false
        });
    }
}

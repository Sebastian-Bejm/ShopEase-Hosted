using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Replace with actual logic to retrieve user info
        var identity = new ClaimsIdentity(); // unauthenticated
        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }
}

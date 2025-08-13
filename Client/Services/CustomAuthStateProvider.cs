using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using ShopEase.Shared.Models;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _http;

    public CustomAuthStateProvider(HttpClient http)
    {
        _http = http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userInfo = await _http.GetFromJsonAsync<UserInfo>("api/account/user");

            if (userInfo is not null && userInfo.IsAuthenticated)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userInfo.UserName)
                }, "ServerAuth");

                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
        }
        catch
        {
            // Ignore errors and treat as unauthenticated
        }

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }
}

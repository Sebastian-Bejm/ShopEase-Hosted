using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using ShopEase.Shared.Services;

public class CartServiceWrapper
{
    private readonly Lazy<Task<CartService>> lazyCart;

    public CartServiceWrapper(IJSRuntime jsRuntime, AuthenticationStateProvider authProvider)
    {
        lazyCart = new Lazy<Task<CartService>>(async () =>
        {
            var authState = await authProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            string userId = user.Identity?.IsAuthenticated == true
                ? user.Identity.Name ?? "anonymous"
                : "anonymous";

            return new CartService(jsRuntime, userId);
        });
    }

    public Task<CartService> GetCartServiceAsync() => lazyCart.Value;
}

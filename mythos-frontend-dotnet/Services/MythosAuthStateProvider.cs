using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace mythos_frontend_dotnet.Services
{
    public class MythosAuthStateProvider(IJSRuntime js, JwtParser parser) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await js.InvokeAsync<string>("localStorage.getItem", "access_token");

            if (string.IsNullOrEmpty(token))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var principal = parser.ParseClaimsFromJwt(token);
            return new AuthenticationState(principal);
        }

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<string?> GetUserIdAsync()
        {
            var authState = await GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return null;

            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

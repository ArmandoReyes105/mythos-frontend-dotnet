using Microsoft.AspNetCore.Components.Authorization;
using mythos_frontend_dotnet.Models;
using System.Net.Http.Json;
using System.Security.Claims;

namespace mythos_frontend_dotnet.Services
{
    public class MythosAuthStateProvider(HttpClient httpClient) : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var response = await httpClient.GetAsync($"account/");
                var user = await response.Content.ReadFromJsonAsync<CompleteAccountModel>();

                if (user is null) return new AuthenticationState(anonymous);

                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.AccountId),
                    new(ClaimTypes.Name, user.Username),
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.Role, user.Role)
                };

                var identity = new ClaimsIdentity(claims, "Cookie");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting authentication state: {ex.Message}");
                return new AuthenticationState(anonymous);
            }
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

        public async Task<string?> GetAuthUsernameAsync()
        {
            var authState = await GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return null;

            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public Task MarkUserAsLoggedOut()
        {
            var anonAuthState = new AuthenticationState(anonymous);
            NotifyAuthenticationStateChanged(Task.FromResult(anonAuthState));
            return Task.CompletedTask;
        }
    }
}

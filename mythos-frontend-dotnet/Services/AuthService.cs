
using System.Net.Http.Json;
using Microsoft.JSInterop;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public class AuthService(
        HttpClient httpClient, 
        IJSRuntime js,
        MythosAuthStateProvider authProvider) : IAuthService
    {
        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            var request = new
            {
                Username = loginModel.Email,
                loginModel.Password
            };

            var response = await httpClient.PostAsJsonAsync("auth/login", request);

            if (!response.IsSuccessStatusCode)
                return false;

            var tokens = await response.Content.ReadFromJsonAsync<TokenResponse>();
            await js.InvokeVoidAsync("localStorage.setItem", "access_token", tokens!.AccessToken);
            await js.InvokeVoidAsync("localStorage.setItem", "refresh_token", tokens.RefreshToken);
            authProvider.NotifyAuthenticationStateChanged();

            return true;
        }

        public async Task LogoutAsync()
        {
            await js.InvokeVoidAsync("localStorage.removeItem", "access_token");
            await js.InvokeVoidAsync("localStorage.removeItem", "refresh_token");
            authProvider.NotifyAuthenticationStateChanged();
        }
    }
}

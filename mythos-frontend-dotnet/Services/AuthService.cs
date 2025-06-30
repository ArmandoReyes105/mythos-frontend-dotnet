
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public class AuthService(
        HttpClient httpClient,
        MythosAuthStateProvider authProvider) : IAuthService
    {
        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "auth/login")
            {
                Content = JsonContent.Create(loginModel)
            };

            requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
                return false;

            authProvider.NotifyAuthenticationStateChanged();
            return true;
        }

        public async Task<bool> RegisterAsync(UserAccountModel registerModel)
        {
            var response = await httpClient.PostAsJsonAsync("auth/register", registerModel);

            return response.IsSuccessStatusCode;
        }

        public async Task LogoutAsync()
        {
            try
            {
                await httpClient.PostAsync("auth/logout", null);
            }
            catch
            {
                Console.WriteLine("Cerrando sesión localmente");
            }

            await authProvider.MarkUserAsLoggedOut();
        }
    }
}

using Microsoft.AspNetCore.Components.WebAssembly.Http;
using mythos_frontend_dotnet.Models;
using System.Net.Http.Json;

namespace mythos_frontend_dotnet.Services
{
    public class AccountService(HttpClient httpClient, MythosAuthStateProvider authProvider) : IAccountService
    {
        public async Task<UserAccountModel?> GetUserAccountAsync()
        {
            var response = await httpClient.GetAsync($"account/");

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<UserAccountModel>();
            return result;
        }

        public async Task<bool> UpdateAccountAsync(UserAccountModel model)
        {
            var userId = await authProvider.GetUserIdAsync();
            var response = await httpClient.PutAsJsonAsync($"account/{userId}", model);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = await authProvider.GetUserIdAsync();

            var response = await httpClient.PutAsJsonAsync($"account/{userId}/password", model);

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("No tienes permiso para cambiar esta contraseña");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> BecomeWriterAsync(PersonModel model)
        {
            var response = await httpClient.PostAsJsonAsync("account/become-writer", model);
            return response.IsSuccessStatusCode;
        }
    }
}

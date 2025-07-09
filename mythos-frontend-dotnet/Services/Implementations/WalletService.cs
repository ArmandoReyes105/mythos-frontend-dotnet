using System.Net.Http.Json;
using mythos_frontend_dotnet.Models;
using mythos_frontend_dotnet.Services.Interfaces;

namespace mythos_frontend_dotnet.Services.Implementations;

public class WalletService(HttpClient dotnetClient) : IWalletService
{
    public async Task<WalletModel?> GetMyWalletAsync()
    {
        var response = await dotnetClient.GetAsync($"wallet");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<WalletModel>();
    }
}

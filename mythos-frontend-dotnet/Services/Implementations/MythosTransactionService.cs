using System;
using System.Net.Http.Json;
using mythos_frontend_dotnet.Models;
using mythos_frontend_dotnet.Services.Interfaces;

namespace mythos_frontend_dotnet.Services.Implementations;

public class MythosTransactionService(HttpClient dotnetClient) : IMythosTransactionService
{
    public async Task<List<PurchaseModel>?> GetPurchaseByChapterAsync(string chapterId)
    {
        var response = await dotnetClient.GetAsync($"mythos-transactions/by-chapter/{chapterId}");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<List<PurchaseModel>>();
    }

    public async Task<List<MythosTransactionModel>?> GetReceivedTransactionsAsync()
    {
        var response = await dotnetClient.GetAsync($"mythos-transactions/received");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<List<MythosTransactionModel>>();
    }

    public async Task<List<MythosTransactionModel>?> GetSentTransactionsAsync()
    {
        var response = await dotnetClient.GetAsync($"mythos-transactions/sent");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<List<MythosTransactionModel>>();
    }
}

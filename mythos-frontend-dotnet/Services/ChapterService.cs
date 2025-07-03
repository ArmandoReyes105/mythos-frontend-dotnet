using System.Net;
using System.Net.Http.Json;
using mythos_frontend_dotnet.Clients;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public class ChapterService(NodeApiClient nodeApiClient, HttpClient dotnetClient) : IChapterService
    {
        private readonly HttpClient nodeClient = nodeApiClient.Client;

        public async Task<bool> CreateChapterAsync(CreateChapterModel chapter)
        {
            var response = await nodeClient.PostAsJsonAsync("chapters", chapter);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ChapterModel>?> GetChaptersByNovel(string novelId)
        {
            var response = await nodeClient.GetAsync($"chapters/novel/{novelId}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return [];

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<List<ChapterModel>>();
        }

        public async Task<ChapterModel?> GetChapterByIdAsync(string chapterId)
        {
            var response = await nodeClient.GetAsync($"chapters/{chapterId}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ChapterModel>();
        }

        public async Task<List<string>?> GetPurchasedChaptersAsync()
        {
            var response = await dotnetClient.GetAsync("purchases/contents");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<List<string>>();
        }

        public async Task<PurchaseResultModel> PurchaseChapterAsync(string chapterId, int price)
        {
            var response = await dotnetClient.PostAsJsonAsync("purchases/buy",
            new
            {
                contentId = chapterId,
                price = price
            });

            var result = await response.Content.ReadFromJsonAsync<PurchaseResultModel>();

            return result ?? new() { Success = false, Message = "Respuesta nula" };
        }
    }
}

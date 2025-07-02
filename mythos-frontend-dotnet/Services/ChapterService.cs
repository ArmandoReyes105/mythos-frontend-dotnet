using System.Net;
using System.Net.Http.Json;
using mythos_frontend_dotnet.Clients;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public class ChapterService(NodeApiClient nodeApiClient) : IChapterService
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
    }
}

using System;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using mythos_frontend_dotnet.Clients;
using mythos_frontend_dotnet.Models;
using mythos_frontend_dotnet.Services.Interfaces;

namespace mythos_frontend_dotnet.Services.Implementations;

public class NovelService(NodeApiClient nodeClient) : INovelService
{
    private HttpClient _nodeClient = nodeClient.Client;

    public async Task<bool> CreateNovelAsync(CreateNovelModel novel)
    {
        var response = await _nodeClient.PostAsJsonAsync("novels", novel);
        return response.IsSuccessStatusCode;
    }

    public async Task<string> UploadCoverImageAsync(IBrowserFile file)
    {
        using var content = new MultipartFormDataContent();

        var streamContent = new StreamContent(file.OpenReadStream(20 * 1024 * 1024));
        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

        content.Add(streamContent, "coverImage", file.Name);

        var response = await _nodeClient.PostAsync("novels/upload/cover-image", content);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Error al subir la imagen");

        var imageUrl = await response.Content.ReadAsStringAsync();

        return imageUrl.Trim('"');
    }

    public async Task<List<NovelModel>?> GetNovelsAsync()
    {
        var response = await _nodeClient.GetAsync("novels/search/title/e");

        if (!response.IsSuccessStatusCode)
            return null;

        var rawList = await response.Content.ReadFromJsonAsync<List<NovelModel>>();

        if (rawList is null)
            return null;

        return rawList;
    }

    public async Task<NovelModel?> GetNovelByIdAsync(string id)
    {
        var response = await _nodeClient.GetAsync($"novels/{id}");

        if (!response.IsSuccessStatusCode)
            return null;

        var rawNovel = await response.Content.ReadFromJsonAsync<NovelModel>();

        if (rawNovel is null)
            return null;

        return rawNovel;
    }

    public async Task<List<NovelModel>?> GetNovelsByWriterAsync(string writerId)
    {
        var response = await _nodeClient.GetAsync($"novels/search/writer/{writerId}");
        var result = await response.Content.ReadFromJsonAsync<List<NovelModel>>();
        return result;
    }

    public async Task<bool> UpdateNovelAsync(CreateNovelModel novel, string novelId)
    {
        var response = await _nodeClient.PutAsJsonAsync($"novels/{novelId}", novel);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteNovelAsync(string novelId)
    {
        var response = await _nodeClient.DeleteAsync($"novels/{novelId}");
        return response.IsSuccessStatusCode;
    }
}

using System;
using System.Net.Http.Json;
using mythos_frontend_dotnet.Clients;
using mythos_frontend_dotnet.Models;
using mythos_frontend_dotnet.Services.Interfaces;

namespace mythos_frontend_dotnet.Services.Implementations;

public class ReviewService(NodeApiClient nodeClient) : IReviewService
{
    private HttpClient _nodeClient = nodeClient.Client;
    public async Task<List<ReviewModel>?> GetReviewsByNovelAsync(string novelId)
    {
        var response = await _nodeClient.GetAsync($"reviews/search/novel-id/{novelId}");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<List<ReviewModel>>();
    }

    public async Task<bool> CreateReviewAsync(ReviewModel review)
    {
        var response = await _nodeClient.PostAsJsonAsync("reviews", review);
        return response.IsSuccessStatusCode;
    }
}

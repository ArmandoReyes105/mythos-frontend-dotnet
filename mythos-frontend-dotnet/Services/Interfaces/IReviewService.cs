using System;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services.Interfaces;

public interface IReviewService
{
    Task<List<ReviewModel>?> GetReviewsByNovelAsync(string novelId);
    Task<bool> CreateReviewAsync(ReviewModel review);
}

using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public interface IChapterService
    {
        Task<bool> CreateChapterAsync(CreateChapterModel chapter);
        Task<List<ChapterModel>?> GetChaptersByNovel(string novelId);
        Task<ChapterModel?> GetChapterByIdAsync(string chapterId);
        Task<List<string>?> GetPurchasedChaptersAsync();
        Task<PurchaseResultModel> PurchaseChapterAsync(string chapterId, string writerId, int price);
        Task<bool> UpdateChapterAsync(CreateChapterModel chapter, string chapterId);
    }
}

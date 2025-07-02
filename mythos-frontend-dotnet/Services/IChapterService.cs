using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public interface IChapterService
    {
        Task<bool> CreateChapterAsync(CreateChapterModel chapter);
        Task<List<ChapterModel>?> GetChaptersByNovel(string novelId);
    }
}

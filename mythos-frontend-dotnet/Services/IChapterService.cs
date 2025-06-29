using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public interface IChapterService
    {
        Task<Chapter?> GetChapterAsync(int id);
        Task<bool> MarkAsReadAsync(int id);
    }
}

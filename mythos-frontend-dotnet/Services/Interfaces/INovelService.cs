using System;
using Microsoft.AspNetCore.Components.Forms;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services.Interfaces;

public interface INovelService
{
    Task<string> UploadCoverImageAsync(IBrowserFile file);
    Task<bool> CreateNovelAsync(CreateNovelModel novel);
    Task<List<NovelModel>?> GetNovelsAsync();
    Task<NovelModel?> GetNovelByIdAsync(string id);
    Task<List<NovelModel>?> GetNovelsByWriterAsync(string writerId);
    Task<bool> UpdateNovelAsync(CreateNovelModel novel, string novelId);
}

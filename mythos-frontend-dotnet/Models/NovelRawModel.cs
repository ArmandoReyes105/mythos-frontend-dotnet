using System;

namespace mythos_frontend_dotnet.Models;

public class NovelRawModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<List<string>> Genres { get; set; } = [];
    public List<string> Tags { get; set; } = [];
    public string CoverImageUrl { get; set; } = string.Empty;
    public string WriterAccountId { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;

namespace mythos_frontend_dotnet.Models;

public class ChapterModel
{
    public string Id { get; set; } = string.Empty;
    public string NovelId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int PriceMythras { get; set; } = 0;
    public int ChapterNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsFree { get; set; }

}

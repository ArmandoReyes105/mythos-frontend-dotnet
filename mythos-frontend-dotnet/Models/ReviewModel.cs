using System;

namespace mythos_frontend_dotnet.Models;

public class ReviewModel
{
    public string AccountId { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string NovelId { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Username { get; set; } = string.Empty;
}

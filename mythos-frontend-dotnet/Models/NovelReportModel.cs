namespace mythos_frontend_dotnet.Models;

public class NovelReportModel
{
    public string NovelId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string WriterName { get; set; } = string.Empty;
    public int TotalMythras { get; set; }
    public List<ChapterReportModel> Chapters { get; set; } = new();
}

public class ChapterReportModel
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int ChapterNumber { get; set; }
    public int PriceMythras { get; set; }
    public int TotalPurchases { get; set; }
    public int TotalMythras { get; set; }
}

public class ContentStatModel
{
    public string ContentId { get; set; }
    public int TotalPurchases { get; set; }
    public int TotalMythras { get; set; }
    public int PricePerPurchase { get; set; }
}

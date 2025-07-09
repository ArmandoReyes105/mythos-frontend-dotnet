using System;

namespace mythos_frontend_dotnet.Models;

public class PurchaseModel
{
    public int PurchaseId { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string ContentId { get; set; } = string.Empty;
    public int MythrasPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
}

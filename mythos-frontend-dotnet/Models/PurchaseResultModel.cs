using System;

namespace mythos_frontend_dotnet.Models;

public class PurchaseResultModel
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int NewBalance { get; set; }
}

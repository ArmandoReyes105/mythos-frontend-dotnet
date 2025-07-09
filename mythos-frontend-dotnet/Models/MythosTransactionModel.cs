using System;

namespace mythos_frontend_dotnet.Models;

public class MythosTransactionModel
{
    public int MythosTransactionId { get; set; }
    public int Type { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string AccountId { get; set; } = string.Empty;
    public string CounterpartyAccountId { get; set; } = string.Empty;
}

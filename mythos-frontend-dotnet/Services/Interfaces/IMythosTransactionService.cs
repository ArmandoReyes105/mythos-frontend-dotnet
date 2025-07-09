using System;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services.Interfaces;

public interface IMythosTransactionService
{
    Task<List<MythosTransactionModel>?> GetReceivedTransactionsAsync();
    Task<List<MythosTransactionModel>?> GetSentTransactionsAsync();
    Task<List<PurchaseModel>?> GetPurchaseByChapterAsync(string chapterId);
}

using System;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services.Interfaces;

public interface IWalletService
{
    Task<WalletModel?> GetMyWalletAsync();
}

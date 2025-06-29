using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginModel loginModel);
        Task<bool> RegisterAsync(UserAccountModel registerModel);

        Task LogoutAsync();
    }
}

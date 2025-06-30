using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public interface IAccountService
    {
        Task<UserAccountModel?> GetUserAccountAsync();
        Task<bool> UpdateAccountAsync(UserAccountModel model);
        Task<bool> ChangePasswordAsync(ChangePasswordModel model);
        Task<bool> BecomeWriterAsync(PersonModel model);
    }
}

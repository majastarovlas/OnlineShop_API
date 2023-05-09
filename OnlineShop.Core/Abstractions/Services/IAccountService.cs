using OnlineShop.Core.Models.Dtos.Accounts;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Abstractions.Services
{
    public interface IAccountService
    {
        Task<ICollection<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(Guid id);
        Task<Account> CreateAccountAsync(CreateAccountDto accountDto);
        Task<Account> UpdateAccountAsync(UpdateAccountDto accountDto);
        Task RemoveAccountAsync(Guid id);
    }
}

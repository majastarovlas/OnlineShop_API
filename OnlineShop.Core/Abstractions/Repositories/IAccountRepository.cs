using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        IQueryable<AccountEntity> GetAllAccounts(bool trackChanges = false);
        Task<AccountEntity?> GetAccountByIdAsync(Guid id, bool trackChanges = false);
        void CreateAccount(AccountEntity account);
    }
}

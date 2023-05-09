using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Data.Repositories
{
    public class AccountRepository : RepositoryBase<AccountEntity>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<AccountEntity> GetAllAccounts(bool trackChanges)
            => FindAll(trackChanges).Where(x => !x.IsDeleted);

        public async Task<AccountEntity?> GetAccountByIdAsync(Guid id, bool trackChanges)
            => await FindByCondition(x => x.Id == id && !x.IsDeleted, trackChanges).FirstOrDefaultAsync();

        public void CreateAccount(AccountEntity account) => Create(account);
    }
}

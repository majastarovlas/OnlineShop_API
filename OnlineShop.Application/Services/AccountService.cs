using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Exceptions;
using OnlineShop.Common.PasswordHasher;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Accounts;
using OnlineShop.Core.Models.Entities;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Application.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<ICollection<Account>> GetAllAccountsAsync()
        {
            var queryable = RepositoryManager.Account.GetAllAccounts()
                .Select(x => x.ToViewModel());

            var result = await queryable.ToListAsync();

            return result;
        }

        public async Task<Account> GetAccountByIdAsync(Guid id)
        {
            var entity = await RepositoryManager.Account.GetAccountByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Account not found by id.");
            }

            var result = entity.ToViewModel();

            return result;
        }

        public async Task<Account> CreateAccountAsync(CreateAccountDto accountDto)
        {
            var entity = new AccountEntity();

            entity.Id = Guid.NewGuid();

            entity.FirstName = accountDto.FirstName;
            entity.LastName = accountDto.LastName;
            entity.Email = accountDto.Email;
            entity.PasswordHash = PasswordHasher.HashPassword(accountDto.Password);

            RepositoryManager.Account.CreateAccount(entity);

            await RepositoryManager.SaveAsync();

            var created = await RepositoryManager.Account.GetAccountByIdAsync(entity.Id);

            if (created == null)
            {
                throw new NotFoundException("Account not found by id.");
            }

            var result = created.ToViewModel();

            return result;
        }

        public async Task<Account> UpdateAccountAsync(UpdateAccountDto accountDto)
        {
            var entity = await RepositoryManager.Account.GetAccountByIdAsync(accountDto.Id, trackChanges: true);

            if (entity == null)
            {
                throw new NotFoundException("Account not found by id.");
            }

            entity.FirstName = accountDto.FirstName;
            entity.LastName = accountDto.LastName;

            await RepositoryManager.SaveAsync();

            var updated = await RepositoryManager.Account.GetAccountByIdAsync(entity.Id);

            if (updated == null)
            {
                throw new NotFoundException("Account not found by id.");
            }

            var result = updated.ToViewModel();

            return result;
        }

        public async Task RemoveAccountAsync(Guid id)
        {
            var entity = await RepositoryManager.Account.GetAccountByIdAsync(id, trackChanges: true);

            if (entity == null)
            {
                throw new NotFoundException("Account not found by id.");
            }

            entity.IsDeleted = true;

            await RepositoryManager.SaveAsync();
        }
    }
}

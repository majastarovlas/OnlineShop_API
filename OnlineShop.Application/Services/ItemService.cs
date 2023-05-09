using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Exceptions;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Items;
using OnlineShop.Core.Models.Entities;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Application.Services
{
    public class ItemService : BaseService, IItemService
    {
        public ItemService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<ICollection<Item>> GetAllItemsAsync()
        {
            var items = RepositoryManager.Item
                .GetAllItems()
                .Include(x => x.Account)
                .Include(x => x.Product)
                .Select(x => x.ToViewModel());

            var result = await items.ToListAsync();

            return result;
        }

        public async Task<Item> GetItemByIdAsync(Guid id)
        {
            var entity = await RepositoryManager.Item.GetItemByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Item not found by id.");
            }

            var result = entity.ToViewModel();

            return result;
        }

        public async Task<Item> CreateItemAsync(CreateItemDto itemDto)
        {
            var entity = new ItemEntity
            {
                Id = Guid.NewGuid(),
                AccountId = itemDto.AccountId,
                ProductId = itemDto.ProductId,
                Quantity = itemDto.Quantity,
            };

            RepositoryManager.Item.CreateItem(entity);

            await RepositoryManager.SaveAsync();

            var created = await RepositoryManager.Item.GetItemByIdAsync(entity.Id);

            if (created == null)
            {
                throw new NotFoundException("Item not found by id.");
            }

            var result = created.ToViewModel();

            return result;
        }

        public async Task<Item> UpdateItemAsync(UpdateItemDto itemDto)
        {
            var entity = await RepositoryManager.Item.GetItemByIdAsync(itemDto.Id, trackChanges: true);

            if (entity == null)
            {
                throw new NotFoundException("Item not found by id.");
            }

            entity.Quantity = itemDto.Quantity;
            entity.AccountId = itemDto.AccountId;
            entity.ProductId = itemDto.ProductId;

            await RepositoryManager.SaveAsync();

            var updated = await RepositoryManager.Item.GetItemByIdAsync(entity.Id);

            if (updated == null)
            {
                throw new NotFoundException("Item not found by id.");
            }

            var result = updated.ToViewModel();

            return result;
        }

        public async Task RemoveItemAsync(Guid id)
        {
            var entity = await RepositoryManager.Item.GetItemByIdAsync(id, trackChanges: true);

            if (entity == null)
            {
                throw new NotFoundException("Item not found by id.");
            }

            entity.IsDeleted = true;

            await RepositoryManager.SaveAsync();
        }
    }
}

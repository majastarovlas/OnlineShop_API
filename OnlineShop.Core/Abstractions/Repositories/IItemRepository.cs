using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IItemRepository
    {
        IQueryable<ItemEntity> GetAllItems(bool trackChanges = false);
        Task<ItemEntity?> GetItemByIdAsync(Guid id, bool trackChanges = false);
        void CreateItem(ItemEntity item);
    }
}

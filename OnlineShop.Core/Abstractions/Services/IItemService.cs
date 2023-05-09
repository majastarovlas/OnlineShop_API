using OnlineShop.Core.Models.Dtos.Items;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Abstractions.Services
{
    public interface IItemService
    {
        Task<ICollection<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(Guid id);
        Task<Item> CreateItemAsync(CreateItemDto itemDto);
        Task<Item> UpdateItemAsync(UpdateItemDto itemDto);
        Task RemoveItemAsync(Guid id);
    }
}

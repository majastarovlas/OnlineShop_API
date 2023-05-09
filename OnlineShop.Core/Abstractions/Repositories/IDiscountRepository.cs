using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IDiscountRepository
    {
        void CreateDiscount(DiscountEntity discount);
        Task<DiscountEntity?> GetDiscountByIdAsync(Guid id, bool trackChanges = false);
        Task<DiscountEntity?> GetDiscountByProductIdAsync(Guid productId, bool trackChanges = false);
    }
}

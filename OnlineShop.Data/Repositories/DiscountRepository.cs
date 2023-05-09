using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Data.Repositories
{
    public class DiscountRepository : RepositoryBase<DiscountEntity>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateDiscount(DiscountEntity discount) => Create(discount);

        public async Task<DiscountEntity?> GetDiscountByIdAsync(Guid id, bool trackChanges)
            => await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();

        public async Task<DiscountEntity?> GetDiscountByProductIdAsync(Guid productId, bool trackChanges)
            => await FindByCondition(x => x.ProductId == productId, trackChanges).FirstOrDefaultAsync();
    }
}

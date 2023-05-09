using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Data.Repositories
{
    public class ItemRepository : RepositoryBase<ItemEntity>, IItemRepository
    {
        public ItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<ItemEntity> GetAllItems(bool trackChanges)
            => FindAll(trackChanges).Where(x => !x.IsDeleted);

        public async Task<ItemEntity?> GetItemByIdAsync(Guid id, bool trackChanges)
            => await FindByCondition(x => x.Id == id && !x.IsDeleted, trackChanges)
            .Include(x => x.Account)
            .Include(x => x.Product.Discount)
            .FirstOrDefaultAsync();

        public void CreateItem(ItemEntity item) => Create(item);
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Data.Repositories
{
    public class BillRepository : RepositoryBase<BillEntity>, IBillRepository
    {
        public BillRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<BillEntity> GetAllBills(bool trackChanges)
            => FindAll(trackChanges);

        public void CreateBill(BillEntity bill) => Create(bill);

        public async Task<BillEntity?> GetBillByIdAsync(Guid id, bool trackChanges)
            => await FindByCondition(x => x.Id == id, trackChanges)
            .Include(x => x.Items)
                .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync();
    }
}

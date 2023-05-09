using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IBillRepository
    {
        IQueryable<BillEntity> GetAllBills(bool trackChanges = false);
        void CreateBill(BillEntity bill);
        Task<BillEntity?> GetBillByIdAsync(Guid id, bool trackChanges = false);
    }
}

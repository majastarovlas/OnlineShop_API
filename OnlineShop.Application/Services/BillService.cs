using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Exceptions;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Bills;
using OnlineShop.Core.Models.Entities;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Application.Services
{
    public class BillService : BaseService, IBillService
    {
        public BillService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<Bill> CreateBillAsync(CreateBillDto billDto)
        {
            var entity = new BillEntity();

            entity.Id = Guid.NewGuid();

            await GetTotalPrice(entity, billDto.ItemIds);

            RepositoryManager.Bill.CreateBill(entity);

            await RepositoryManager.SaveAsync();

            var created = await RepositoryManager.Bill.GetBillByIdAsync(entity.Id);

            if (created == null)
            {
                throw new NotFoundException("Bill not found by id.");
            }

            var result = created.ToViewModel();

            return result;
        }

        public async Task<ICollection<Bill>> GetAllBillsAsync()
        {
            var billsQuery = RepositoryManager.Bill
                .GetAllBills()
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                .Select(x => x.ToViewModel());

            var result = await billsQuery.ToListAsync();

            return result;
        }

        private async Task<double> GetTotalPrice(BillEntity entity, ICollection<Guid> itemIds)
        {
            double totalPrice = 0;

            foreach (var itemId in itemIds)
            {
                var itemEntity = await RepositoryManager.Item.GetItemByIdAsync(itemId, trackChanges: true);

                if (itemEntity == null)
                {
                    continue;
                }

                itemEntity.BillId = entity.Id;

                double priceWithoutDiscount = itemEntity.Product.Price * itemEntity.Quantity;

                if (itemEntity.Product.Discount != null)
                {
                    double priceWithDiscount = priceWithoutDiscount - (priceWithoutDiscount * ((double)itemEntity.Product.Discount.Value / 100));
                    totalPrice += priceWithDiscount;
                }
                else
                {
                    totalPrice += priceWithoutDiscount;
                }
            }

            entity.TotalPrice = totalPrice;

            return totalPrice;
        }
    }
}

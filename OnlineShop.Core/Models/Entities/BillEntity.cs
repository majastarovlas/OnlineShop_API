using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Models.Entities
{
    public class BillEntity : BaseEntity
    {
        public double TotalPrice { get; set; }
        public ICollection<ItemEntity> Items { get; set; } = null!;

        public Bill ToViewModel()
        {
            return new Bill
            {
                Id = Id,
                CreatedDate = CreatedDate,
                TotalPrice = TotalPrice,
                Items = Items.Select(x => new ItemForBill
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    ProductName = x.Product.Name
                }).ToList()
            };
        }
    }
}
